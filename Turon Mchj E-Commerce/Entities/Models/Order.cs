using Turon_Mchj_E_Commerce.Entities.Commons;

namespace Turon_Mchj_E_Commerce.Entities.Models
{
    public class Order : Auditable
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public OrderCondition Condition { get; set; }
    }
}
