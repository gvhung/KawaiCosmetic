using RussianKawaiShop.Database.Models;
using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private OrderService orderService = new OrderServiceImpl();
        private PartnerService partnerService = new PartnerServiceImpl();

        public override bool Init(Client client)
        {
            if (client.ConnType == ConnectionType.WebSocket)
            {
                if (client.WSData != null)
                {
                    string[] WSData = Regex.Split(client.WSData, BaseFuncs.WSplit);
                    string Action = WSData[0];

                    if (Action == "AddProductToCartAction")
                    {
                        WebSocket.WSPeople++;
                        if (this.AddToCart(WSData[1], WSData[2], WSData[3], client))
                        {
                            client.SendWebsocket("CountItemsInCartAction" + BaseFuncs.WSplit + cartService.CountProductsNum(cartService.GetCookie(client)));
                        }
                    }
                }
                return false;
            }
            else if (client.PostParam("action") != null)
            {
                string Action = client.PostParam("action");
                if (Action == "AddProductToCartAction")
                {
                    WebSocket.JSPeople++;
                    if (this.AddToCart(client.PostParam("id"), client.PostParam("num"), client.PostParam("productColor"), client))
                    {
                        client.HttpSend(cartService.CountProductsNum(cartService.GetCookie(client)).ToString());
                        return false;
                    }
                }
            }

            if (client.PostParam("ClearCart") != null)
            {
                cartService.SetNewCookie(client);
                client.Redirect("/cart/");
                return false;
            }
            else if (client.PostParam("CreateOrder") != null)
            {
                Order order = new Order();
                order.Email = client.PostParam("email");
                order.Name = client.PostParam("name");
                order.Country = client.PostParam("country");
                order.City = client.PostParam("city");
                order.Region = client.PostParam("region");
                order.Street = client.PostParam("street");
                order.Phone = client.PostParam("phone");
                order.Home = client.PostParam("home");
                order.Room = client.PostParam("room");
                order.Index = client.PostParam("index");

                if(client.PostParam("saleCode") != null)
                {
                    Partner pr = partnerService.GetByLogin(client.PostParam("saleCode"));
                    if(pr != null)
                    {
                        order.PartnerID = pr.ID;
                    }
                }

                Order orderResult = orderService.CreateOrder(order, client);
                if (orderResult != null)
                {
                    client.Redirect("/order/" + orderResult.UniqueCode);
                    return false;
                }
            }
            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
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
