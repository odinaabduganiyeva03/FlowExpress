using FlowExpress.Domain.Commons;

namespace FlowExpress.Domain.Entities
{
    public class Food : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
