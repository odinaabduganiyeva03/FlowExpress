using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;

namespace FlowExpress.Service.Interfaces
{
    public interface IUserService
    {
        Task<Response<User>> CreateAsync(UserCreationDTO user);
        Task<Response<User>> UpdateAsync(long id, UserCreationDTO user);
        Task<Response<bool>> DeleteAsync(long id);
        Task<Response<User>> GetAllAsync();
        
    }
}
