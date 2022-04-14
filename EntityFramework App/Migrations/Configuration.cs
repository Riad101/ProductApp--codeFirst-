namespace EntityFramework_App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework_App.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityFramework_App.Models.CompanyDbContext context)
        {
            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Sony" }, new Models.Brand() { BrandID = 2, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Home Appliances" }, new Models.Category() { CategoryID = 2, CategoryName = "LifeStyle" });

        }
    }
}
