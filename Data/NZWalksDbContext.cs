using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.Data
{
    // DbContext is inherited as it will be used to interact with database 
    // It is going to work as middleware between Models and Database
    //   Microsoft.EntityFrameworkCore library is used for DbContext
    public class NZWalksDbContext : DbContext
    {
        // Type ctor and press tab twice to get constructor

        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

    }
}
