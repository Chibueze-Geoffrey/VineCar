using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VineCar.Entities
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        public ICollection<Car> Cars { get; set; }
              = new List<Car>();
        public Brand(string name) 
        {
            Name = name;
        }
    }
}
