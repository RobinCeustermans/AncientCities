using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApiCityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _unitOfWork.CityRepository.GetAll(includeProperties: "Type").ToList();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = _unitOfWork.CityRepository.Get(x => x.Id == id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.CityRepository.Add(city);
            _unitOfWork.Save();

            return Ok(city);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.CityRepository.Update(city);
            _unitOfWork.Save();

            return Ok(city);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _unitOfWork.CityRepository.Get(x => x.Id == id);
            if (city == null)
                return NotFound();

            _unitOfWork.CityRepository.Remove(city);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
