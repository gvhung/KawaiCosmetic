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
    class EditProductPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/product/edit/"; }
        }
        public override string TemplateAddr
        {
            get { return "Products.Edit.html"; }
        }

        private ProductService productService = new ProductServiceImpl();
        public override bool Init(Client client)
        {
            int productID;
            if(int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0], out productID))
            {
                Product product = productService.GetByID(productID);
                if(product != null)
                {
                    Hashtable data = new Hashtable();

                    if (client.PostParam("EditProduct") != null)
                    {
                        double price;
                        int category;
                        if (double.TryParse(client.PostParam("price"), out price) && int.TryParse(client.PostParam("category"), out category))
                        {
                            productService.EditProduct(client.PostParam("name"), client.PostParam("jpname"), price, client.PostParam("desc"), client.PostParam("images"), category, client.PostParam("volume"), client.PostParam("productsInCat"), client.PostParam("productColors"), productID);
                            client.Redirect("/products/#pr_" + product.ID);
                            Logger.ConsoleLog("Edited product: " + product.Name + " (ID: " + product.ID + ")", ConsoleColor.Yellow);

                            return false;
                        }
                    }
                    data.Add("Product", product);
                    client.HttpSend(TemplateActivator.Activate(this, client, data));
                    return true;
                }  
            }


            BaseFuncs.Show404(client);
            return false;
        }
    }
}
