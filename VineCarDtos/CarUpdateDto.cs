using System.ComponentModel.DataAnnotations;

namespace VineCar.VineCarDtos
{
    public class CarUpdateDto
    {
        [Required(ErrorMessage = "You should provide a value for Name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? Description { get; set; }
        private decimal? price;
        [Required(ErrorMessage = "Provide a price for the created Car")]
        public decimal Price { get; set; }
    }
}
