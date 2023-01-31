using CarShop.Data.Interfaces;
using CarShop.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllCars _carRep;
        private IShopCartItem _itemRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart, IShopCartItem item)
        {
            _carRep = carRep;
            _shopCart = shopCart;
            _itemRep = item;
        }

        public ViewResult Index() 
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult deleteFromCart(int id)
        {
            _itemRep.deleteItem(id);
        
            return RedirectToAction("Index");
        }
    }
}
