using AncientCities.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AncientCities.Web.ViewModels
{
    public class CityViewModel
    {
        public City City { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CityTypes { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EraNames { get; set; }

        public int? EraCreatedInt { get; set; }  
        public int? EraDefunctInt { get; set; }  
    }
}
