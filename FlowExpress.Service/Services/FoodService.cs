using FlowExpress.Data.Repositories;
using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;
using FlowExpress.Service.Interfaces;

namespace FlowExpress.Service.Services
{
    public class FoodService : IFoodService
    {
        public GenericRepository<Food> genericRepository = new GenericRepository<Food>();
        public async Task<Response<Food>> CreateAsync(FoodCreationDTO food)
        {
            var values = await genericRepository.GetAllAsync();
            var value = values.FirstOrDefault(v => v.Name == food.Name);
            if(value is not null)
            {
                value.Count += food.Count;

                return new Response<Food>()
                {
                    StatusCode = 403,
                    Message = "Food is already exists",
                    FValue =  null
                };
            }

            var changedValue = new Food
            {
                Name = food.Name,
                Count = food.Count,
                Description = food.Description,
                Price = food.Price
            };

            await genericRepository.CreateAsync(changedValue);
            return new Response<Food>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = changedValue
            };
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var values = await genericRepository.GetByIdAsync(id);
            if(values is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "Food is not found",
                    FValue = false
                };
            }

            var value = await genericRepository.DeleteAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = true
            };
        }

        public async Task<Response<List<Food>>> GetAllAsync()
        {
            var result = await genericRepository.GetAllAsync();
            return new Response<List<Food>>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = result
            };
        }

        public async Task<Response<Food>> GetByIdAsync(long id)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if(model is null)
            {
                return new Response<Food>()
                {
                    StatusCode = 404,
                    Message = "Food is not found",
                    FValue = null
                };
            }

            return new Response<Food>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = model
            };
        }

        public async Task<Response<Food>> UpdateAsync(long id, FoodCreationDTO food)
        {
            var value = await genericRepository.GetByIdAsync(id);
            if(value is null)
            {
                return new Response<Food>()
                {
                    StatusCode = 404,
                    Message = "Food is not found",
                    FValue = null
                };
            }

            var mappedValue = new Food()
            {
                Name = food.Name,
                Count = food.Count,
                Description = food.Description,
                Price = food.Price
            };

            var result = await genericRepository.UpdateAsync(id, mappedValue);
            return new Response<Food>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = result
            };
        }
    }
}
