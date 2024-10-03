using AncientCities.Data.DbApplicationContext;
using AncientCities.Data.Repository.Interfaces;
using AncientCities.Models;
using AncientCities.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utility.CommonData;
using Utility.Helpers;

namespace AncientCities.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<City> list = _unitOfWork.CityRepository.GetAll(includeProperties: "Type").ToList();
            return View(list);
        }


        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> typeList = _unitOfWork.CityTypeRepository.GetAll().ToList().Select(x =>
               new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            CityViewModel cityViewModel = new CityViewModel()
            {
                CityTypes = typeList,
                City = new City(),
                EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>()
            };

            ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

            if (id == null || id == 0)
            {
                return View(cityViewModel);
            }
            else
            {
                cityViewModel.City = _unitOfWork.CityRepository.Get(x => x.Id == id);
                if (cityViewModel.City == null)
                    return NotFound();

                cityViewModel.EraCreatedInt = cityViewModel.City.EraCreated == "BC" ? 0 : cityViewModel.EraCreatedInt = cityViewModel.City.EraCreated == "AD" ? 1 : null;
                cityViewModel.EraDefunctInt = cityViewModel.City.EraDefunct == "BC" ? 0 : cityViewModel.EraDefunctInt = cityViewModel.City.EraDefunct == "AD" ? 1 : null;

                ViewBag.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();

                return View(cityViewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CityViewModel cityViewModel)
        {
            if (ModelState.IsValid)
            {
                cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 0 ? "BC" : cityViewModel.City.EraCreated = cityViewModel.EraCreatedInt == 1 ? "AD" : null;
                cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 0 ? "BC" : cityViewModel.City.EraDefunct = cityViewModel.EraDefunctInt == 1 ? "AD": null;

                if (cityViewModel.City.Id == 0)
                {
                    _unitOfWork.CityRepository.Add(cityViewModel.City);
                }
                else
                {
                    _unitOfWork.CityRepository.Update(cityViewModel.City);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            cityViewModel.EraNames = EnumHelper.GetEnumSelectList<Era.EraNames>();
            return View(cityViewModel);
        }

        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.CityRepository.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CityRepository.Remove(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
