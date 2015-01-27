using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class CartPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/cart/"; }
        }
        public override string TemplateAddr
        {
            get { return "Cart.html"; }
        }

        private CartService cartService = new CartServiceImpl();

        public override bool Init(Client client)
        {
            if (client.PostParam("ClearCart") != null)
            {
                cartService.SetNewCookie(client);
                client.Redirect("/cart/");
            }
            else
            {
                client.HttpSend(TemplateActivator.Activate(this, client));
            }

            return true;
        }
    }
}
