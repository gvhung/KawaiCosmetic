using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Services
{
    public interface CartService
    {
        string GetCookie(Client client);
        string SetNewCookie(Client client);
        List<Cart> GetByCookie(string cookie);
        bool AddProduct(int productID, int productNum, string cookie);
        Cart GetByCookieAndProductID(string cookie, int productId);
        int CountProductsNum(string cookie);
        double GetTotalCost(List<Cart> carts);
        double GetTotalCost(string cookie);
    }
}
