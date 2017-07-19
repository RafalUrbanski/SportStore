using SportStore.Domain.Entities;

namespace SportStore.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportStore.Domain.Entities.SportsStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportStore.Domain.Entities.SportsStoreContext context)
        {
            context.Products.AddOrUpdate(x => x.Name, 
                new Product{Name = "Rakieta", Category = "Tenis ziemny", Price = 545, Description = "Podstawowy sprzet"},
                new Product{Name = "Korki", Category = "Pilka nozna", Price = 234, Description = "Cos do biegania"},
                new Product{Name = "Pi³ka Tenisowa", Category = "Tenis ziemny", Price = 5, Description = "Zabawka dla Tosi"},
                new Product{Name = "Owijka", Category = "Tenis ziemny", Price = 6, Description = "Grip musi byc"},
                new Product{Name = "Naci¹g", Category = "Tenis ziemny", Price = 55, Description = "Moc i kontrola"},
                new Product{Name = "Ochraniacze", Category = "Pilka nozna", Price = 74, Description = "Zeby nie bolalo"}
                );
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
