using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop.Services
{
    public interface ProductService
    {
        Product CreateProduct(String Name, String JPName, int price, string desc, string img, int categoryID);
        Product GetByID(int id);
        List<Product> GetAll();
        ProductCategory GetCategory(Product product);
        double GetPrice(Product product);
        List<string> GetImages(Product product);
    }
}
