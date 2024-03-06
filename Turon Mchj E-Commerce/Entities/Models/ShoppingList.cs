using Turon_Mchj_E_Commerce.Entities.Commons;

namespace Turon_Mchj_E_Commerce.Entities.Models
{
    public class ShoppingList : Auditable
    {
        public Guid PersonId { get; set; }

        public IList<Order> OrderList { get; set; }

        public DateTime OrderedAt { get; set; }

        public string Description { get; set; }
    }
}
