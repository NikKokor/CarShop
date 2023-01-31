using CarShop.Models;

namespace CarShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currentCategory { get; set; }
    }
}
