using System.Collections.Generic;

namespace VineCar.VineCarDtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }
        public ICollection<CarDto> Cars { get; set; }
              = new List<CarDto>();
        public int NumberOfCars
        {
            get
            {
                return Cars.Count;
        }   }
    }
}
