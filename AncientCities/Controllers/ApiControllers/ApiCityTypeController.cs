using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCityTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApiCityTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetCityTypes()
        {
            var cityTypes = _unitOfWork.CityTypeRepository.GetAll().ToList();
            return Ok(cityTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityType(int id)
        {
            var cityType = _unitOfWork.CityTypeRepository.Get(x => x.Id == id);
            if (cityType == null)
                return NotFound();

            return Ok(cityType);
        }

        [HttpPost]
        public IActionResult CreateCityType([FromBody] CityType cityType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.CityTypeRepository.Add(cityType);
            _unitOfWork.Save();

            return Ok(cityType);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCityType(int id, [FromBody] CityType cityType)
        {
            if (id != cityType.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.CityTypeRepository.Update(cityType);
            _unitOfWork.Save();

            return Ok(cityType);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCityType(int id)
        {
            var city = _unitOfWork.CityTypeRepository.Get(x => x.Id == id);
            if (city == null)
                return NotFound();

            _unitOfWork.CityTypeRepository.Remove(city);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
