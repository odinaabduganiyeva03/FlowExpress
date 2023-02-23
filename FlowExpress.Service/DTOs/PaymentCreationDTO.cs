using FlowExpress.Domain.Entities;
using FlowExpress.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowExpress.Service.DTOs
{
    public class PaymentCreationDTO
    {
        public PaymentType Type { get; set; }
        public long OrderId { get; set; }
        public bool IsPaid { get; set; }

    }
}
