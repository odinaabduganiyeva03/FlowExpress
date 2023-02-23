namespace FlowExpress.Data.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<T> CreateAsync(T value);
        Task<T> UpdateAsync(long id, T value);
        Task<bool> DeleteAsync(long id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
