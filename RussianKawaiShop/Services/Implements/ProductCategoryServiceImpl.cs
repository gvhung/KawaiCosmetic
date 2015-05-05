using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RussianKawaiShop
{
    public class ProductCategoryServiceImpl : ProductCategoryService
    {
        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = DBConnector.manager.FastSelect<ProductCategory>(data => true);
            return productCategories;
        }

        public ProductCategory CreateCategory(string Name)
        {
            if(Name != null)
            {
                ProductCategory productCategory = new ProductCategory();
                productCategory.Name = Name;
                productCategory.ID = DBConnector.manager.InsertQueryReturn(productCategory);
                return productCategory;
            }

            return null;
        }

        public ProductCategory GetByName(string Name)
        {
            List<ProductCategory> productCategories = DBConnector.manager.FastSelect<ProductCategory>(data =>
            {
                if((data as ProductCategory).Name == Name)
                {
                    return true;
                }

                return false;
            });
            if (productCategories.Count > 0)
            {
                return productCategories[0];
            }

            return null;
        }

        public ProductCategory GetByID(int id)
        {
            List<ProductCategory> productCategory = DBConnector.manager.FastSelect<ProductCategory>(data => 
            { 
                if((data as ProductCategory).ID == id)
                {
                    return true;
                }

                return false;
            });

            if(productCategory.Count > 0)
            {
                return productCategory[0];
            }
            return null;
        }

        public List<Product> GetProductsInCategory(int CategoryID)
        {
            List<Product> products = DBConnector.manager.FastSelect<Product>(data =>
            {
                if((data as Product).CategoryId == CategoryID)
                {
                    return true;
                }
                return false;
            });
            
            return products;
        }

        public void EditCategory(ProductCategory productCategory)
        {
            if(productCategory.Name != null)
            {
                DBConnector.manager.FastUpdate<ProductCategory>(data => 
                {
                    ProductCategory pcat = data as ProductCategory;
                    if(pcat.ID == productCategory.ID)
                    {
                        return productCategory;
                    }
                    return null;
                });
            }
        }
    }
}
