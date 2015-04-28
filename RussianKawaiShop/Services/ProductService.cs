using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;

namespace RussianKawaiShop
{
    public interface ProductService
    {
        Product CreateProduct(String Name, String JPName, double price, string desc, string img, int categoryID, string volume, string productsInCategory, string colors, string Image30x68, string Image178x170, string Image60x135);
        void EditProduct(String Name, String JPName, double price, string desc, string img, int categoryID, string volume, string productsInCategory, string colors, string Image30x68, string Image178x170, string Image60x135, int ID);
        Product GetByID(int id);
        List<Product> GetAll();
        ProductCategory GetCategory(Product product);
        double GetPrice(Product product);
        double GetPrice(int productID);
        List<string> GetImages(Product product);
        List<Product> GetProductsInCategory(Product product);
        List<ProductColor> GetProductColors(Product product);
    }
}
