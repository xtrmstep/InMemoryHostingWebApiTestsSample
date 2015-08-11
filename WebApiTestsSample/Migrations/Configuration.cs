using System.Data.Entity.Migrations;
using WebApiTestsSample.Models;

namespace WebApiTestsSample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApiDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApiDataContext context)
        {
            context.Items.AddOrUpdate(
                p => p.Name,
                new Item
                {
                    Name = "Andrew Peters"
                },
                new Item
                {
                    Name = "Brice Lambson"
                },
                new Item
                {
                    Name = "Rowan Miller"
                });
        }
    }
}