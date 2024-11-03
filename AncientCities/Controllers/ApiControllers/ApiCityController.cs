using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AncientCities.Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ApiCityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
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
            var city = _unitOfWork.CityRepository.Get(x => x.Id == id, includeProperties: "CityImages");
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromForm] City city, [FromForm] IFormFile[] images)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.CityRepository.Add(city);
            _unitOfWork.Save();

            await SaveImages(city, images);
            _unitOfWork.Save();

            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromForm] City city, [FromForm] IFormFile[] images)
        {
            if (id != city.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCity = _unitOfWork.CityRepository.Get(c => c.Id == id, includeProperties: "CityImages");
            if (existingCity == null)
                return NotFound();

            // Use AutoMapper to map properties from `city` to `existingCity`
            _mapper.Map(city, existingCity);

            await SaveImages(existingCity, images);

            _unitOfWork.CityRepository.Update(existingCity);
            _unitOfWork.Save();

            return Ok(existingCity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _unitOfWork.CityRepository.Get(x => x.Id == id, includeProperties: "CityImages");
            if (city == null)
                return NotFound();

            foreach (var image in city.CityImages)
            {
                var filePath = Path.Combine("wwwroot/images", image.ImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _unitOfWork.CityRepository.Remove(city);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("deleteImage/{imageId}")]
        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfWork.CityImageRepository.Get(x => x.Id == imageId);
            int cityId = imageToBeDeleted.CityId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                _unitOfWork.CityImageRepository.Remove(imageToBeDeleted);
                _unitOfWork.Save();
            }

            return Ok(new { message = "Image deleted successfully", cityId });
        }

        private async Task SaveImages(City city, IFormFile[] images)
        {
            var cityId = city.Id;
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var cityImageDirectory = Path.Combine(wwwrootPath, $"images\\cities\\city-{cityId}");

            if (!Directory.Exists(cityImageDirectory))
            {
                Directory.CreateDirectory(cityImageDirectory);
            }

            foreach (var file in images)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(cityImageDirectory, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var image = new CityImage
                {
                    CityId = cityId,
                    ImageUrl = $"\\images\\cities\\city-{cityId}\\{uniqueFileName}"
                };

                if (city.CityImages == null)
                {
                    city.CityImages = new List<CityImage>();
                }

                city.CityImages.Add(image);
            }
        }
    }
}
