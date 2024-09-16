using System.ComponentModel.DataAnnotations;

namespace AncientCities.Models
{
    public class CityType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
