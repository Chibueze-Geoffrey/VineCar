using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VineCar.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }
        public int BrandId { get; set; }
      
        public Car(string name)
        {
            Name= name;
        }
    }

}
