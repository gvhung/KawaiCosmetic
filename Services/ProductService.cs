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
        Product CreateProduct(String name);
        Product GetByID(int id);
        List<Product> GetAll();
    }
}
