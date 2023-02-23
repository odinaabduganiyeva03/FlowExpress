using FlowExpress.Domain.Commons;

namespace FlowExpress.Service.DTOs
{
    public class UserCreationDTO : Auditable
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
