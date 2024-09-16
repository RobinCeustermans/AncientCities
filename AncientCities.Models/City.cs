using System.ComponentModel.DataAnnotations;
using Utility.CommonData;

namespace AncientCities.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Part of")]
        public string PartOf { get; set; }

        [Display(Name = "Estimated population")]
        public int? Population { get; set; }

        public DateTime? Created { get; set; }

        private string? _eraCreated;

        public string? EraCreated
        {
            get
            {
                if (Created.HasValue)
                {
                    return Created.Value.Year > 0 ? Era.EraNames.AD.ToString() : Era.EraNames.BC.ToString();
                }
                return null;
            }
            set 
            {
                _eraCreated = value;
            }
        }

        public DateTime? Defunct { get; set; }

        private string? _eraDefunct;

        public string? EraDefunct
        {
            get
            {
                if (Defunct.HasValue)
                {
                    return Defunct.Value.Year > 0 ? Era.EraNames.AD.ToString() : Era.EraNames.BC.ToString();
                }
                return null;
            }
            set
            {
                _eraDefunct = value;
            }
        }
        public string? Description { get; set; }



        //Foreign Key

        public int? TypeId { get; set; }

        public CityType? Type { get; set; }
    }
}
