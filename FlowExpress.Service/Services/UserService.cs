using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;
using FlowExpress.Service.Interfaces;

namespace FlowExpress.Service.Services
{
    public class UserService : IUserService
    {
        public Task<Response<User>> CreateAsync(UserCreationDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<User>> UpdateAsync(long id, UserCreationDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
