using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;

namespace RussianKawaiShop
{
    public interface ProductService
    {
        Product CreateProduct(String Name, String JPName, double price, string desc, string img, int categoryID);
        void EditProduct(String Name, String JPName, double price, string desc, string img, int categoryID, int ID);
        Product GetByID(int id);
        List<Product> GetAll();
        ProductCategory GetCategory(Product product);
        double GetPrice(Product product);
        double GetPrice(int productID);
        List<string> GetImages(Product product);
    }
}
