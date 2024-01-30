using AutoMapper;

namespace VineCar.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Entities.Car, VineCarDtos.CarDto>();
            CreateMap<VineCarDtos.CarCreationDto, Entities.Car>();
            CreateMap<VineCarDtos.CarUpdateDto, Entities.Car>();
            CreateMap<Entities.Car,VineCarDtos.CarUpdateDto>();
        }
    }
}
