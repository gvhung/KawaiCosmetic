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
        List<Cart> GetByCookies(string cookie);
        bool AddProduct(int productID, int productNum, string cookie);
        Cart GetByCookiesAndProduct(string cookie, int productId);
    }
}
