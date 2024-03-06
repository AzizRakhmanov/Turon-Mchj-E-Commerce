using Turon_Mchj_E_Commerce.Entities.Commons;

namespace Turon_Mchj_E_Commerce.Entities.Models
{
    public class Product : Auditable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ProducedDate { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public string ProducedPlace { get; set; }
    }
}
