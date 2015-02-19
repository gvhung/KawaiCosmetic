using RussianKawaiShop;
using RussianKawaiShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages
{
    public class CreateProductColorPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/product.color/create/"; }
        }
        public override string TemplateAddr
        {
            get { return "ProductColors.Create.html"; }
        }

        private ProductColorService productColorService = new ProductColorServiceImpl();
        public override bool Init(Client client)
        {
            if (client.PostParam("AddProductColor") != null)
            {
                if (client.PostParam("ColorRGB") != null && client.PostParam("name") != null)
                {
                    ProductColor pColor = new ProductColor();
                    pColor.RGB = client.PostParam("ColorRGB");
                    pColor.Name = client.PostParam("name");

                    ProductColor productColor = productColorService.CreateProductColorReturn(pColor);
                    if (productColor != null)
                    {
                        client.Redirect("/product.color/#pr_" + productColor.ID);
                        Logger.ConsoleLog("Added new product color: " + productColor.RGB + " (ID: " + productColor.ID + ")", ConsoleColor.Yellow);

                        return false;
                    }
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
