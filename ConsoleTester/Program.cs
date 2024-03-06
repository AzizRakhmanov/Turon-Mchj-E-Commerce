using Turon_Mchj_E_Commerce.Database.Repository;
using Turon_Mchj_E_Commerce.DataBase;
using Turon_Mchj_E_Commerce.DataBase.IRepository;
using Turon_Mchj_E_Commerce.Entities.Models;

namespace ConsoleTester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ITuronRepository<Product> db = new TuronRepository<Product>(new TuronDbContext());


            //IEnumerable<Product> all = new List<Product>() {
            //new Product()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Shaftoli"
            //},
            //new Product()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Ananas"
            //}
            //     };

            //await db.InsertAsync(all);


            var result = db.DeleteMany(p => p.Name == "Olma");

            Console.WriteLine(result);

        }
    }
}
