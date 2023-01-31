using CarShop.Data.Interfaces;
using CarShop.Models;

namespace CarShop.Data.Repository
{
    public class ItemReposytory : IShopCartItem
    {
        private readonly AppDBContent appDBContent;

        public ItemReposytory(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public void deleteItem(int id)
        {
            ShopCartItem item = appDBContent.ShopCartItem.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                appDBContent.Remove(item);
            }

            appDBContent.SaveChanges();
        }
    }
}
