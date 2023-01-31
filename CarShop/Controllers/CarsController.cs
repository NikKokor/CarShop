using CarShop.Data.Interfaces;
using CarShop.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Data.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _carsCategory = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(_category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            } else
            {
                if (string.Equals("electro", _category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", _category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                    currCategory = "Классические автомобили";
                }

                
            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currentCategory = currCategory,
            };

            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
