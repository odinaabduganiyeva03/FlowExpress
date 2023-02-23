using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;

namespace FlowExpress.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<Payment>> CreateAsync(PaymentCreationDTO food);
        Task<Response<Payment>> UpdateAsync(long id,PaymentCreationDTO  payment);
        Task<Response<bool>> DeleteAsync(long id);
        Task<Response<Payment>> GetByIdAsync(long id);
        Task<Response<List<Payment>>> GetAllAsync();
    }
}
