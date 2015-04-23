using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class CatalogPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/catalog/"; }
        }
        public override string TemplateAddr
        {
            get { return "Catalog.html"; }
        }

        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();

        public override bool Init(Client client)
        {
            int categoryId = 1;
            string[] url = BaseFuncs.GetAdditionalURLArray(client.URL, URL);
            if(url.Length > 1)
            {
                int.TryParse(url[1], out categoryId);
            }

            ProductCategory productCategory = productCategoryService.GetByID(categoryId);
            if(productCategory == null)
            {
                productCategory = productCategoryService.GetByID(1);
            }

            Hashtable data = new Hashtable();
            data.Add("productCategory", productCategory);
            data.Add("menuActive", "catalog");
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
