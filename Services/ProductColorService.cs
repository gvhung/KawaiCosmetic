using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public interface ProductColorService
    {
        List<ProductColor> GetAll();
        ProductColor GetByID(int id);
        void CreateProductColor(ProductColor productColor);
        ProductColor CreateProductColorReturn(ProductColor productColor);
        ProductColor EditProductColor(string rgb, string name, int id);
    }
}
