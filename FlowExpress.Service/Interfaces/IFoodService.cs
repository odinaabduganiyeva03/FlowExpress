using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;

namespace FlowExpress.Service.Interfaces
{
    public interface IFoodService
    {
        Task<Response<Food>> CreateAsync(FoodCreationDTO food);
        Task<Response<Food>> UpdateAsync(long id, FoodCreationDTO food);
        Task<Response<bool>> DeleteAsync(long id);
        Task<Response<Food>> GetByIdAsync(long id);
        Task<Response<List<Food>>> GetAllAsync();
    }
}
