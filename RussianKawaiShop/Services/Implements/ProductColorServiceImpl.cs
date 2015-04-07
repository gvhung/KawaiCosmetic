using RussianKawaiShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public class ProductColorServiceImpl : ProductColorService
    {
        public List<ProductColor> GetAll()
        {
            return DBConnector.manager.FastSelect<ProductColor>(data => true);
        }
        public ProductColor GetByID(int id)
        {
            List<ProductColor> productColors = DBConnector.manager.FastSelect<ProductColor>(data => (data as ProductColor).ID == id);

            if(productColors.Count > 0)
            {
                return productColors[0];
            }

            return null;
        }

        public void CreateProductColor(ProductColor productColor)
        {
            if (productColor != null && productColor.RGB != null)
            {
                DBConnector.manager.InsertQuery(productColor);
            }
        }

        public ProductColor CreateProductColorReturn(ProductColor productColor)
        {
            if (productColor != null && productColor.RGB != null)
            {
                return this.GetByID(DBConnector.manager.InsertQueryReturn(productColor));
            }

            return null;
        }

        public ProductColor EditProductColor(string rgb, string name, int id)
        {
            ProductColor productColor = this.GetByID(id);
            if(productColor != null)
            {
                DBConnector.manager.FastUpdate<ProductColor>(data =>
                {
                    ProductColor pColor = (data as ProductColor);
                    if ((data as ProductColor).ID == id)
                    {
                        pColor.RGB = rgb;
                        pColor.Name = name;
                        return pColor;
                    }
                    return null;
                });

                return productColor;
            }

            return null;
        }
    }
}
