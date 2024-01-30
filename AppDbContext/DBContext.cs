using Microsoft.EntityFrameworkCore;
using VineCar.Entities;

namespace VineCar.AppDbContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext>options):base(options) { }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Car> cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().
                HasData(
                new Brand("MERCEDES")
                {
                    
                    Id = 1,
                    Description = "A BRAND THAT DOES IT ALL"
                },
                 new Brand("BMW")
                 {
                     Id = 2,
                     Description = "A BRAND THAT HAS ALL THE REQUIREMENTS"
                 },
                  new Brand("HONDA")
                  {
                      Id = 3,
                      Description = "A BRAND JUST FOR YOU"
                  },
                 new Brand("TOYOTA")
                 {
                     Id = 4,
                     Description = "A BRAND THAT REPRESENTS"
                 });
            modelBuilder.Entity<Car>().
               HasData(
               new Car("GLK350")
               {
                   BrandId = 1,
                   Id = 100,
                   Description = "A Car with essential requirements",
                   Price = 20000000,

               },
                new Car("Mercedes100")
                {
                    BrandId = 1,
                    Id = 101,
                    Description = "Durable and efficient",
                    Price = 1500000
                },
                 new Car("X6")
                 {
                     BrandId = 2,
                     Id = 102,
                     Description = "A Car Known for its uniqueness",
                     Price = 19000000
                 },
                  new Car("X7")
                  {
                      BrandId = 2,
                      Id = 103,
                      Description = "Exotic with distinct properties",
                      Price = 23000000
                  },
                   new Car("Honda200")
                   {
                       BrandId = 3,
                       Id = 104,
                       Description = "A Car with essentials",
                       Price = 1000000
                   },
                    new Car("Honda-Civic")
                    {
                        BrandId = 3,
                        Id = 105,
                        Description = "A Car That is efficient and worthy",
                        Price = 1500000
                    },
                     new Car("Camry200")
                     {
                         BrandId = 4,
                         Id = 106,
                         Description = "A Car with Robust features",
                     },
               new Car("Corolla112")
               {
                   BrandId = 4,
                   Id = 107,
                   Description = "A Car with a pocket friendly price",
                   Price = 900000

               });



            base.OnModelCreating(modelBuilder);
        }

    }
}
