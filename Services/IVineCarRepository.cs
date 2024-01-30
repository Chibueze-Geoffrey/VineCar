using VineCar.Entities;

namespace VineCar.Services
{
    public interface IVineCarRepository
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<IEnumerable<Brand>> GetBrandsAsync(string? name,string? searchQuery, 
            int PageNumber, int PageSize);
        Task<Brand?> GetBrandAsync(int brandId, bool includeNumberOfCars);
        Task<bool> BrandExistsAsync(int brandId);
        Task<IEnumerable<Car>> GetCarForBrandAsync(int brandId);
        Task<Car?> GetCarForBrandAsync(int brandId,
           int carId);
        Task AddCarForBrandAsync(int brandId, Car car);
        void DeleteCar(Car car);
       Task<bool> SaveChangesAsync();
    }
}
