using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineCar.Services;
using VineCar.VineCarDtos;

namespace VineCar.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IVineCarRepository _carVineRepository;
        private readonly IMapper _mapper;
        const int maxPage = 20;

        public BrandController(IVineCarRepository carVineRepository,
            IMapper mapper)
        {
             _carVineRepository = carVineRepository  ??
                throw new ArgumentNullException(nameof(carVineRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands(string? name,string? searchQuery
            ,int PageNumber = 1,int PageSize = 10)
        {
            if (PageSize> maxPage)
            {
                 PageSize = maxPage;
            }
            var brandIdentity = await _carVineRepository.GetBrandsAsync(name, searchQuery,PageNumber,PageSize);
            return Ok(_mapper.Map<IEnumerable<BrandDto>>(brandIdentity));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(
            int id, bool includeNumberOfCars = false)
        {
            var city = await _carVineRepository.GetBrandAsync(id, includeNumberOfCars);
            if (city == null)
            {
                return NotFound();
            }

            if (includeNumberOfCars)
            {
                return Ok(_mapper.Map<BrandDto>(city));
            }

            return Ok(_mapper.Map<BrandWithoutCarsDto>(city));
        }
    }
}
