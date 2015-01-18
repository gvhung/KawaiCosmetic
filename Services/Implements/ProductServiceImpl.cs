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
        public Product CreateProduct(String name)
        {
            Product product = new Product();
            product.Name = name;
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
    }
}
