using RussianKawaiShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages.Products
{
    class CreateProductPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/product/create/"; }
        }
        public override string TemplateAddr
        {
            get { return "Products.Create.html"; }
        }

        private ProductService productService = new ProductServiceImpl();
        public override bool Init(Client client)
        {
            if (client.PostParam("AddProduct") != null)
            {
                double price;
                int category;
                if (double.TryParse(client.PostParam("price"), out price) && int.TryParse(client.PostParam("category"), out category))
                {
                    Product product = productService.CreateProduct(client.PostParam("name"), client.PostParam("jpname"), price, client.PostParam("desc"), client.PostParam("images"), category, client.PostParam("volume"), client.PostParam("productsInCat"));
                    if(product != null)
                    {
                        client.Redirect("/products/#pr_" + product.ID);
                        Logger.ConsoleLog("Added new product: " + product.Name + " (ID: " + product.ID + ")", ConsoleColor.Yellow);

                        return false;
                    }
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
