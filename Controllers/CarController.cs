using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VineCar.Entities;
using VineCar.Services;
using VineCar.VineCarDtos;

namespace VineCar.Controllers
{
    [Route("api/brands/{brandId}/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IVineCarRepository _carVineRepository;
        private readonly IMapper _mapper;

        public CarController(ILogger<CarController> logger,
            IVineCarRepository carVineRepository,
            IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _carVineRepository = carVineRepository ??
                throw new ArgumentNullException(nameof(carVineRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars(
            int brandId)
        {
            if (!await _carVineRepository.BrandExistsAsync(brandId))
            {
                _logger.LogInformation(
                    $"City with id {brandId} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var carForCity = await _carVineRepository
                .GetCarForBrandAsync(brandId);

            return Ok(_mapper.Map<IEnumerable<CarDto>>(carForCity));
        }

        [HttpGet("{carId}", Name = "GetCar")]
        public async Task<ActionResult<CarDto>> GetCar(
            int brandId, int carId)
        {
            if (!await _carVineRepository.BrandExistsAsync(brandId))
            {
                return NotFound();
            }

            var car = await _carVineRepository
                .GetCarForBrandAsync(brandId, carId);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CarDto>(car));
        }

    [HttpPost]
        public async Task<ActionResult<CarDto>> CarCreation(int brandId, CarCreationDto carCreationDto)
        {
            if (!await _carVineRepository.BrandExistsAsync(brandId))
            {
                return NotFound();
            }
            var final = _mapper.Map<Entities.Car>(carCreationDto);
            await _carVineRepository.AddCarForBrandAsync(brandId, final);
            await _carVineRepository.SaveChangesAsync();
            var created = _mapper.Map<VineCarDtos.CarDto>(final);
            return CreatedAtRoute("GetCar",
                new
                {
                    brandId = brandId,
                    carId = created.Id
                },
                created);
        }
        [HttpPut("{carId}")]
        public async Task<ActionResult> CarUpdate (int brandId,int carId, CarUpdateDto carUpdateDto)
        {
            if (!await _carVineRepository.BrandExistsAsync (brandId))
            {
                return NotFound();
            }
            var getCar = await _carVineRepository.GetCarForBrandAsync(brandId,carId);
            if(getCar == null)
            {
                return NotFound();
            }
            _mapper.Map(carUpdateDto, getCar);
            await _carVineRepository.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{carId}")]
        public async Task<ActionResult> PartialUpdate(int brandId, int carId,
           JsonPatchDocument<CarUpdateDto> carUpdate )
        {
            if(!await _carVineRepository.BrandExistsAsync(brandId))
            {
                return NotFound();
            }
            var getCar = await _carVineRepository.GetCarForBrandAsync (brandId,carId);
            if (getCar==null)
            {
                return NotFound();
            }
            var toPatch = _mapper.Map<CarUpdateDto>(getCar);
            carUpdate.ApplyTo(toPatch, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!TryValidateModel(toPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(toPatch,getCar);
            await _carVineRepository.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{carId}")]
        public async Task<ActionResult> DeleteCar(int brandId,int carId)
        {
            if(!await _carVineRepository.BrandExistsAsync (brandId))
            {
                return NotFound();
            }
            var getCar = await _carVineRepository.GetCarForBrandAsync(brandId, carId);
            if (getCar == null)
            {
                return NotFound();
            }
            _carVineRepository.DeleteCar(getCar);
            await _carVineRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
