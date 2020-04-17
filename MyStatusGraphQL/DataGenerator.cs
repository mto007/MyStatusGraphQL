using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyStatusGraphQL.Database;
using MyStatusGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatusGraphQL
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new MentalStatusDbContext(
             serviceProvider.GetRequiredService<DbContextOptions<MentalStatusDbContext>>());
            // Look for any items
            if (context.MentalStatuses.Any())
            {
                return;   // Data was already seeded
            }
            context.MentalStatuses.AddRange(
                new MentalStatus
                {
                    Id = Guid.NewGuid(),
                    Status = 3,
                    StatusDate = DateTime.Now,
                    AddInfo = "When does this all end?",
                    Latitude = 60.388910M,
                    Longitude = 25.665440M,
                    PostCode = "06100",
                    City = "Porvoo",
                    Sex = 2,
                    Age = 25
                },
                new MentalStatus
                {
                    Id = Guid.NewGuid(),
                    Status = 4,
                    StatusDate = DateTime.Now,
                    AddInfo = "I have renovated the whole house",
                    Latitude = 63.841680M,
                    Longitude = 23.144230M,
                    PostCode = "06100",
                    City = "Porvoo",
                    Sex = 1,
                    Age = 66
                }
                );

            context.SaveChanges();
        }
    }
}
