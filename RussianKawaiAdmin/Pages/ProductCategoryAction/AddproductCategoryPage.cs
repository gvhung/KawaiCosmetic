using RussianKawaiShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages.Products
{
    class AddProductcategoryPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/product.category/add/"; }
        }
        public override string TemplateAddr
        {
            get { return "ProductCategory.Add.html"; }
        }

        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();
        public override bool Init(Client client)
        {
            Hashtable data = new Hashtable();

            if (client.PostParam("AddProductCategory") != null)
            {
                if (client.PostParam("name") != null)
                {
                    ProductCategory productCategory = new ProductCategory();
                    int id = productCategoryService.CreateCategory(client.PostParam("name")).ID;

                    client.Redirect("/product.category/#pr_" + productCategory.ID);
                    Logger.ConsoleLog("Added new product category: " + productCategory.Name + " (ID: " + id + ")", ConsoleColor.Yellow);

                    return false;
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
