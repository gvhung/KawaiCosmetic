using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public class ProductServiceImpl : ProductService
    {
        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();
        private ProductColorService productColorService = new ProductColorServiceImpl();

        public Product CreateProduct(String Name, String JPName, double price, string desc, string img, int categoryID, string volume, string productsInCategory, string colors)
        {
            Product product = new Product();
            product.Name = Name;
            product.JPName = JPName;
            product.Price = price;
            product.Description = desc;
            product.Images = img;
            product.CategoryId = categoryID;
            product.Volume = volume;
            product.ProductsInCategory = this.CorrectProductIDsForCategory(productsInCategory);
            product.Colors = colors;
            DBConnector.manager.InsertQuery(product);

            return product;
        }

        public void EditProduct(String Name, String JPName, double price, string desc, string img, int categoryID, string volume, string productsInCategory, string colors, int ID)
        {
            DBConnector.manager.FastUpdateReturn<Product>(data => {
                Product product = data as Product;
                if (product.ID == ID)
                {
                    product.Name = Name;
                    product.JPName = JPName;
                    product.Price = price;
                    product.Description = desc;
                    product.Images = img;
                    product.CategoryId = categoryID;
                    product.Volume = volume;
                    product.ProductsInCategory = this.CorrectProductIDsForCategory(productsInCategory);
                    product.Colors = colors;
                    return product;
                }

                return null;
            });
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

            return products;
        }

        public ProductCategory GetCategory(Product product)
        {
            return productCategoryService.GetByID(product.CategoryId);
        }

        public double GetPrice(Product product)
        {
            return product.Price * 0.7;
        }

        public double GetPrice(int productID)
        {
            return this.GetPrice(this.GetByID(productID));
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

        public List<Product> GetProductsInCategory(Product product)
        {
            List<Product> products = new List<Product>();

            return this.GetProductsInCategory(product.ProductsInCategory);
        }

        private List<Product> GetProductsInCategory(string productIDs)
        {
            List<Product> products = new List<Product>();

            if (productIDs != null)
            {
                string[] pIDs = productIDs.Split(',');
                foreach (string id in pIDs)
                {
                    int productID;
                    if (int.TryParse(id, out productID))
                    {
                        Product pr = this.GetByID(productID);
                        if (pr != null)
                        {
                            products.Add(pr);
                        }
                    }
                }
            }
            return products;
        }

        private string CorrectProductIDsForCategory(string ids)
        {
            string result = "";

            List<Product> products = this.GetProductsInCategory(ids);
            foreach (Product product in products)
            {
                result += product.ID;
                if (!product.Equals(products[products.Count - 1]))
                {
                    result += ",";
                }
            }

            return result;
        }

        public List<ProductColor> GetProductColors(Product product)
        {
            List<ProductColor> productColors = new List<ProductColor>();
            foreach(string colorID in product.Colors.Split(','))
            {
                productColors.Add(productColorService.GetByID(int.Parse(colorID)));
            }
            return productColors;
        }
    }
}
