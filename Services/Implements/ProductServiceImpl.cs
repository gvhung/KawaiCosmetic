using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop.Services.Implements
{
    public class ProductServiceImpl : ProductService
    {
        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();

        public Product CreateProduct(String Name, String JPName, int price, string desc, string img, int categoryID)
        {
            Product product = new Product();
            product.Name = Name;
            product.JPName = JPName;
            product.Price = price;
            product.Description = desc;
            product.Images = img;
            product.CategoryId = categoryID;
            DBConnector.manager.InsertQuery(product);

            return product;
        }

        public Product GetByID(int id)
        {
            List<Product> products = DBConnector.manager.FastSelect<Product>(data => {
                if (data.ID == id)
                {
                    return true;
                }
                return false;
            });

            if(products.Count > 0)
            {
                return products[0];
            }
            return null;
        }

        public List<Product> GetAll()
        {
            List<Product> products = DBConnector.manager.FastSelect<Product>(data => true);

            if (products.Count > 0)
            {
                return products;
            }

            return null;
        }

        public ProductCategory GetCategory(Product product)
        {
            return productCategoryService.GetByID(product.ID);
        }

        public double GetPrice(Product product)
        {
            return product.Price;
        }

        public List<string> GetImages(Product product)
        {
            List<string> images = new List<string>();
            foreach (string url in product.Images.Split(';'))
            {
                images.Add(url);
            }

            return images;
        }
    }
}
