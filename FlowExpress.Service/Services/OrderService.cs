using FlowExpress.Data.IRepositories;
using FlowExpress.Data.Repositories;
using FlowExpress.Domain.Entities;
using FlowExpress.Domain.Enums;
using FlowExpress.Service.DTOs;
using FlowExpress.Service.Helpers;
using FlowExpress.Service.Interfaces;

namespace FlowExpress.Service.Services
{
    public class OrderService : IOrderService
    {
        public GenericRepository<Order> genericRepository = new GenericRepository<Order>();
        public PaymentService paymentService = new PaymentService();
        public async Task<Response<Order>> CreateAsync(OrderCreationDTO order)
        {
           
            var res = await paymentService.CreateAsync(order.Payment);
            if(res.FValue.IsPaid)
            {
                var mappedOrder = new Order()
                {
                    Foods = order.foods,
                    Payment = res.FValue,
                    OrderType = OrderType.Pending
                };
                var orderRes = await genericRepository.CreateAsync(mappedOrder);

                return new Response<Order>()
                {
                    StatusCode = 200,
                    Message = "Success",
                    FValue = orderRes
                }; 
            }
            return new Response<Order>()
            {
                StatusCode = 402,
                Message = "Payment is not valid",
                FValue = null
            };


        }

        public async Task<Response<Order>> ChangeStatusAsync(long id, OrderType orderType)
        {
            var order = await genericRepository.GetByIdAsync(id);
            if (order is not null)
            {
                order.OrderType = orderType;
                var orderResult = await genericRepository.UpdateAsync(id, order);
                return new Response<Order>()
                { 
                    StatusCode = 200,
                    Message = "Success",
                    FValue = orderResult
                };
            }
            return new Response<Order>()
            {
                StatusCode = 404,
                Message = "Order is not found",
                FValue = null
            };
        }

        public async Task<Response<List<Order>>> GetByAllAsync()
        {
            var orders = await genericRepository.GetAllAsync();
            return new Response<List<Order>>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = orders
            };
        }

        public Task<Response<Order>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Order>> UpdateAsync(long id, OrderCreationDTO order)
        {
            var model = await genericRepository.GetByIdAsync(id);
            if (model is null)
                return new Response<Order>()
                {
                    StatusCode = 404,
                    Message = "Order is not found",
                   FValue = null
                };
            var mappedPayment = new Payment()
            {
                OrderId = order.Payment.OrderId,
                Type = order.Payment.Type,
                IsPaid = order.Payment.IsPaid
            };
            var mappedOrder = new Order()
            {
                Foods = order.foods,
                Payment = mappedPayment,
                OrderType = model.OrderType,
            };

            var orderResult = await this.genericRepository.UpdateAsync(id, mappedOrder);
            return new Response<Order>()
            {
                StatusCode = 200,
                Message = "Success",
                FValue = orderResult
            };
        }
    }
}
