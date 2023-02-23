using FlowExpress.Data.IRepositories;
using FlowExpress.Data.Repositories;
using FlowExpress.Domain.Entities;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;
using FlowExpress.Service.Interfaces;

namespace FlowExpress.Service.Services
{
    public class PaymentService : IPaymentService
    {
        public  IGenericRepository<Payment> genericRepository = new GenericRepository<Payment>();
        public async Task<Response<Payment>> CreateAsync(PaymentCreationDTO food)
        {
            var mappedModel = new Payment()
            {
                Type = food.Type,
                Order = food.Order,
                IsPaid = true
            };
            var res = await genericRepository.CreateAsync(mappedModel);
            return new Response<Payment>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = mappedModel
            };
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if(model is null)
            {
                return new Response<bool>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    FValue = false
                };
            }
            var result = genericRepository.DeleteAsync(id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = true
            };

        }

        public async Task<Response<List<Payment>>> GetAllAsync()
        {
            var models = await genericRepository.GetAllAsync();
            return new Response<List<Payment>>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = models
            };
        }

        public async Task<Response<Payment>> GetByIdAsync(long id)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if(model is null)
            {
                return new Response<Payment>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    FValue = null
                };
            }
            return new Response<Payment>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = model
            };
        }

        public async Task<Response<Payment>> UpdateAsync(long id, PaymentCreationDTO payment)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if(model is null )
            {
                return new Response<Payment>()
                {
                    StatusCode = 404,
                    Message = "Payment is not found",
                    FValue = null
                };
            }

            var mappedModel = new Payment()
            {
                Type = payment.Type,
            };
            var result = await genericRepository.UpdateAsync(id, mappedModel);

            return new Response<Payment>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = result
            };
        }
    }
}
