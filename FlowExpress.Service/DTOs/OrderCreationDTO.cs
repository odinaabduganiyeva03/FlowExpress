using FlowExpress.Domain.Entities;
using FlowExpress.Domain.Enums;

namespace FlowExpress.Service.DTOs
{
    public class OrderCreationDTO
    {
        public List<Food> foods { get; set; }
        //public long UserId { get; set; }
        //public string Address { get; set; }
        public PaymentCreationDTO Payment { get; set; }
    }
}
