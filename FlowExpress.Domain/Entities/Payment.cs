using FlowExpress.Domain.Commons;
using FlowExpress.Domain.Enums;

namespace FlowExpress.Domain.Entities
{
    public class Payment : Auditable
    {
        public PaymentType Type { get; set; }
        public bool IsPaid { get; set; }
        public long OrderId { get; set; }
    }
}
