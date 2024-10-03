using System.ComponentModel.DataAnnotations;

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

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created { get; set; }

        [Display(Name = "Before or after Christ")]
        public string? EraCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Defunct { get; set; }

        [Display(Name = "Before or after Christ")]
        public string? EraDefunct { get; set; }

        public string? Description { get; set; }



        //Foreign Key

        public int? TypeId { get; set; }

        public CityType? Type { get; set; }
    }
}
