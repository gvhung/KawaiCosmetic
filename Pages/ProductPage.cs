using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class ProductPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/product/"; }
        }
        public override string TemplateAddr
        {
            get { return "Product.html"; }
        }

        private ProductService productService = new ProductServiceImpl();
        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();

        public override bool Init(Client client)
        {
            int productId = 0;
            int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, URL)[0], out productId);
            Hashtable data = new Hashtable();

            if (productService.GetByID(productId) != null)
            {
                data.Add("Product", this.productService.GetByID(productId));
                string tosend = TemplateActivator.Activate(this, client, data);
                client.HttpSend(tosend);
            }
            else
            {
                BaseFuncs.Show404(client);
            }

            return true;
        }
    }
}
