using AncientCities.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetCityTypes()
        {
            var cityTypes = _unitOfWork.CityTypeRepository.GetAll().ToList();
            return Ok(cityTypes);
        }
    }
}
