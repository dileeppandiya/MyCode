namespace MyCode.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyCode.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyCode.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Customers.AddOrUpdate(
              c => c.Id,
              new Models.Customer { FirstName = "Dileep", LastName ="Pandiya" },
              new Models.Customer { FirstName = "test", LastName = "Test" },
              new Models.Customer { FirstName = "firstname", LastName = "lastname" }
            );
            //
        }
    }
}
