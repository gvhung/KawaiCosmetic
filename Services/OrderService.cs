using RussianKawaiShop.Database.Models;
using System.Collections.Generic;

namespace RussianKawaiShop.Services
{
    public interface OrderService
    {
        Order GetByID(int id);
        Order GetByUniqueCode(string unicode);
        List<Product> GetProducts(Order order);
        Order CreateOrder(Order order);
        string CreateProducts(List<Cart> carts);
    }
}
