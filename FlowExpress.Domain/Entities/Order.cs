using FlowExpress.Domain.Commons;
using FlowExpress.Domain.Enums;
namespace FlowExpress.Domain.Entities
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public List<Food> Foods { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Pending;
        public Payment Payment { get; set; }
        public string Address { get; set; }
    }
}
