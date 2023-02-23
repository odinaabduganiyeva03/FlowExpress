using FlowExpress.Domain.Entities;
using FlowExpress.Domain.Enums;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;

namespace FlowExpress.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Response<Order>> CreateAsync(OrderCreationDTO order);
        Task<Response<Order>> UpdateAsync(long id, OrderCreationDTO order);
        Task<Response<Order>> ChangeStatusAsync (long id,OrderType orderType);
        Task<Response<Order>> GetByIdAsync(long id);
        Task<Response<List<Order>>> GetByAllAsync();
    }
}
