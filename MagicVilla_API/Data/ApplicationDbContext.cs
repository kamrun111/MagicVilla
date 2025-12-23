using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    VillaId = 1,
                    VillaName = "Royal Villa",
                    Details = "This is the Royal Villa",
                    Rate = 200.0,
                    Sqft = 550,
                    Occupancy = 4,
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new Villa
                {
                    VillaId = 2,
                    VillaName = "Premium Pool Villa",
                    Details = "This is the Premium Pool Villa",
                    Rate = 300.0,
                    Sqft = 550,
                    Occupancy = 4,
                    ImageUrl = "",
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
            );
        }
    }
}
