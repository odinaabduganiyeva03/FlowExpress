using FlowExpress.Data.Constants;
using FlowExpress.Data.IRepositories;
using FlowExpress.Domain.Commons;
using FlowExpress.Domain.Entities;
using Newtonsoft.Json;

namespace FlowExpress.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        private string path;
        private long maxId;

        public GenericRepository()
        {
            if (typeof(T) == typeof(Food))
            {
                path = DatabasePath.FOOD_DATABASE;
            }
            else if (typeof(T) == typeof(Order))
            {
                path = DatabasePath.ORDER_DATABASE;
            }
            else if (typeof(T) == typeof(Payment))
            {
                path = DatabasePath.PAYMENT_DATABASE;
            }
        }

        public async Task<T> CreateAsync(T value)
        {
            value.Id = ++maxId;
            value.CreatedAt = DateTime.UtcNow;

            var values = await GetAllAsync();
            values.Add(value);

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return value;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var values = await GetAllAsync();
            var value = values.FirstOrDefault(x => x.Id == id);

            if (value is null)
                return false;

            values.Remove(value);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);

            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            string models = await File.ReadAllTextAsync(path);
            if (string.IsNullOrEmpty(models))
                models = "[]";

            List<T> results = JsonConvert.DeserializeObject<List<T>>(models);
            return results;
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var values = await GetAllAsync();
            return values.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> UpdateAsync(long id, T value)
        {
            var values = await GetAllAsync();
            var model = values.FirstOrDefault(x => x.Id == id);
            if (model is not null)
            {
                var index = values.IndexOf(model);
                values.Remove(model);

                value.CreatedAt = model.CreatedAt;
                value.UpdatedAt = DateTime.UtcNow;

                values.Insert(index, value);
                var json = JsonConvert.SerializeObject(values, Formatting.Indented);
                await File.WriteAllTextAsync(path, json);
                return model;
            }
            return model;
        }
    }
}

