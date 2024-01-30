using Microsoft.EntityFrameworkCore;
using VineCar.AppDbContext;
using VineCar.Entities;

namespace VineCar.Services
{
    public class VineCarRepository : IVineCarRepository
    {
        private readonly DBContext _context;

        public VineCarRepository(DBContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCarForBrandAsync(int brandId, Car car)
        {
            var brand = await GetBrandAsync(brandId, false);
            if(brand != null)
            {
                brand.Cars.Add(car);
            }
        }

        public async Task<bool> BrandExistsAsync(int brandId)
        {
            return await _context.brands.AnyAsync(c => c.Id == brandId);
        }

        public void DeleteCar(Car car)
        {
            _context.cars.Remove(car);
        }

        public async Task<Brand?> GetBrandAsync(int brandId, bool includeNumberOfCars)
        {
            if (includeNumberOfCars)
            {
                return await _context.brands.Include(c => c.Cars)
                    .Where(c => c.Id == brandId).FirstOrDefaultAsync();
            }

            return await _context.brands
                  .Where(c => c.Id == brandId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.brands.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync(string? name, string? searchQuery, 
            int PageNumber, int PageSize)
        {
            //if(string.IsNullOrEmpty(name)
            //    && string.IsNullOrWhiteSpace(searchQuery))
            //{
            //    return await GetBrandsAsync();
            //}
            var collectionsOfBrands = _context.brands as IQueryable<Brand>;
            if(!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim().ToUpper();
                collectionsOfBrands = collectionsOfBrands.Where(c => c.Name == name);
            }
            if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery=searchQuery.Trim().ToUpper();
                collectionsOfBrands = collectionsOfBrands.Where(b => b.Name.Contains(searchQuery)
                || (b.Description != null && b.Description.Contains(searchQuery)));
            }
                return await collectionsOfBrands.OrderBy(c=>c.Name)
                .Skip(PageSize*(PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<Car?> GetCarForBrandAsync(int brandId, int carId)
        {
            return await _context.cars
               .Where(p => p.BrandId == brandId && p.Id ==carId)
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetCarForBrandAsync(int brandId)
        {
            return await _context.cars
                           .Where(p => p.BrandId == brandId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
