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
    class CartDataPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/cart.data/"; }
        }
        public override string TemplateAddr
        {
            get { return "Cart.CartData.html"; }
        }

        private CartService cartService = new CartServiceImpl();

        public override bool Init(Client client)
        {
            if(cartService.GetByCookie(cartService.GetCookie(client)).Count > 0)
            {
                Hashtable data = new Hashtable();
                data.Add("menuActive", "cart");
                client.HttpSend(TemplateActivator.Activate(this, client, data));
                return true;
            }
            else
            {
                client.Redirect("/cart/");
            }
            return false;
        }
    }
}
