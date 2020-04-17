using Microsoft.EntityFrameworkCore;
using MyStatusGraphQL.Entities;

namespace MyStatusGraphQL.Database
{
    public class MentalStatusDbContext : DbContext
  {
    public MentalStatusDbContext() { }
        public MentalStatusDbContext(DbContextOptions<MentalStatusDbContext> options)
          : base(options)
        { }

        public DbSet<MentalStatus> MentalStatuses { get; set; }
       
    }

}

