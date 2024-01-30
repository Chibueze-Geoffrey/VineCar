using AutoMapper;

namespace VineCar.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Entities.Brand, VineCarDtos.BrandWithoutCarsDto>();
            CreateMap<Entities.Brand, VineCarDtos.BrandDto>();
        }
    }
}
