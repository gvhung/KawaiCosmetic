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
    class EditProductColorPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/product.color/edit/"; }
        }
        public override string TemplateAddr
        {
            get { return "ProductColors.Edit.html"; }
        }

        private ProductColorService productColorService = new ProductColorServiceImpl();
        public override bool Init(Client client)
        {
            int productColorID;
            if (int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0], out productColorID))
            {
                ProductColor productColor = productColorService.GetByID(productColorID);
                if (productColor != null)
                {
                    Hashtable data = new Hashtable();

                    if (client.PostParam("EditProductColor") != null && client.PostParam("name") != null)
                    {
                        if (client.PostParam("RGB") != null)
                        {
                            productColorService.EditProductColor(client.PostParam("RGB"), client.PostParam("name"), productColorID);
                            client.Redirect("/product.color/#pr_" + productColor.ID);
                            Logger.ConsoleLog("Edited product color: " + productColor.RGB + " (ID: " + productColor.ID + ")", ConsoleColor.Yellow);

                            return false;
                        }
                    }
                    data.Add("ProductColor", productColor);
                    client.HttpSend(TemplateActivator.Activate(this, client, data));
                    return true;
                }  
            }

            BaseFuncs.Show404(client);
            return false;
        }
    }
}
