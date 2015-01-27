using RussianKawaiShop.Database.Models;
using System.Collections.Generic;
using UpServer;

namespace RussianKawaiShop.Services
{
    public interface OrderService
    {
        Order GetByID(int id);
        Order GetByUniqueCode(string unicode);
        List<Product> GetProducts(Order order);
        int CountProductsNum(Product product, Order order);
        Order CreateOrder(Order order, Client client);
        string CreateProducts(List<Cart> carts);
    }
}
