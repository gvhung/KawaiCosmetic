using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RussianKawaiShop.Services.Implements
{
    public class ProductCategoryServiceImpl : ProductCategoryService
    {
        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = DBConnector.manager.FastSelect<ProductCategory>(data => true);
            if(productCategories.Count > 0)
            {
                return productCategories;
            }

            return null;
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
    }
}
