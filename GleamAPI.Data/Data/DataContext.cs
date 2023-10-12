using GleamAPI.Entities;
using GleamAPI.Entities.Venue;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace GleamAPI.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<GleamVenue>()
            //    .HasMany(v => v.Reviews)
            //    .WithOne();
        }
        public DbSet<GleamVenue> GleamVenues { get; set; }

        public DbSet<Review> Reviews { get; set; }

        // public DbSet<GleamVenueAddDto> GleamVenuesDtos { get; set; }
    }
}
