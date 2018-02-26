namespace BusinessCards.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusinessCards.Models.BusinessCardDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusinessCards.Models.BusinessCardDBContext context)
        {
            context.BusinessCards.AddOrUpdate(i => i.Name,
                new BusinessCard
                {
                    Name = "Big Boss",
                    CompanyName = "Foxhound",
                    Position = "Commanding Officer",
                    Address = "404 Zanzibar Land",
                    Number = "0207-447-8456",
                    Email = "bb@foxhound.com"
                },

                new BusinessCard
                {
                    Name = "Albert Wesker",
                    CompanyName = "Umbrella Corp.",
                    Position = "T-Virus Researcher",
                    Address = "404 Racoon City",
                    Number = "0208-489-8576",
                    Email = "ab@umbrella.com"
                },

                new BusinessCard
                {
                    Name = "Gannon Dorf",
                    CompanyName = "Triforce",
                    Position = "Overlord",
                    Address = "404 Gerudo Valley",
                    Number = "0207-557-9646",
                    Email = "gannon@triforce.com"
                });
        }
    }
}
