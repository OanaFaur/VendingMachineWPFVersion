namespace DataAccess.Migrations
{
    using DataAccess.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Models.VendingMachineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Models.VendingMachineContext context)
        {
            context.Products.AddOrUpdate(
               p => p.Name,

               new Product { Name = "Coca Cola", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 1 },
               new Product { Name = "Fanta", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 2 },
               new Product { Name = "Sprite", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 3 },
               new Product { Name = "Mars", Price = 3, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 4 },
               new Product { Name = "Mentos", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 5 },
               new Product { Name = "Dr Pepper", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 6 },
               new Product { Name = "Snickers", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 7 },
               new Product { Name = "Milky Way", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 8 },
               new Product { Name = "7Up", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 9 },
               new Product { Name = "Orbit", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 10 },
               new Product { Name = "Mentos", Price = 3.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 11 },
               new Product { Name = "Mints", Price = 2.5, Image = "", ItemsLeft = 10, ItemsSold = 0, Id = 12 }
               );
        }
    }
}
