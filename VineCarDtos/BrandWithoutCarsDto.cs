using System.ComponentModel.DataAnnotations;

namespace VineCar.VineCarDtos
{
    public class BrandWithoutCarsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }
    }
}
