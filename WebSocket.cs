using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    class WebSocket : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/ws/"; }
        }
        public override string TemplateAddr
        {
            get { return "ws.WebSocket.html"; }
        }

        private CartService cartService = new CartServiceImpl();
        private ProductColorService productColorService = new ProductColorServiceImpl();
        public override bool Init(Client client)
        {
            if(client.WSData != null)
            {
                string[] WSData = Regex.Split(client.WSData, BaseFuncs.WSplit);
                string Action = WSData[0];

                if (Action == "AddProductToCartAction")
                {
                    if (this.AddToCart(WSData[1], WSData[2], WSData[3], client))
                    {
                        client.SendWebsocket("CountItemsInCartAction" + BaseFuncs.WSplit + cartService.CountProductsNum(cartService.GetCookie(client)));
                    }
                }
            }
            else if(client.PostParam("action") != null)
            {
                string Action = client.PostParam("action");
                if(Action == "AddProductToCartAction")
                {
                    if (this.AddToCart(client.PostParam("id"), client.PostParam("num"), client.PostParam("productColor"), client))
                    {
                        client.HttpSend(cartService.CountProductsNum(cartService.GetCookie(client)).ToString());
                        return false;
                    }
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client));
            return false;
        }

        private bool AddToCart(string productID, string num, string productColorId, Client client)
        {
            int _productId, _num, _productColorId;

            if (int.TryParse(productID, out _productId) && int.TryParse(num, out _num) && int.TryParse(productColorId, out _productColorId))
            {
                cartService.AddProduct(_productId, _num, cartService.GetCookie(client), _productColorId);
                return true;
            }
            return false;
        }
    }
}
