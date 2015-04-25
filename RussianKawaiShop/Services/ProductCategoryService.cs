using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public interface ProductCategoryService
    {
        List<ProductCategory> GetAll();
        ProductCategory CreateCategory(string Name);
        ProductCategory GetByName(string Name);
        ProductCategory GetByID(int id);
        List<Product> GetProductsInCategory(int CategoryID);
        void EditCategory(ProductCategory productCategory);
    }
}
