using RussianKawaiShop.Database.Models;
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
        private OrderService orderService = new OrderServiceImpl();

        public override bool Init(Client client)
        {
            if (client.PostParam("ClearCart") != null)
            {
                cartService.SetNewCookie(client);
                client.Redirect("/cart/");
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

                client.Redirect("/order/" + orderService.CreateOrder(order, client).UniqueCode);
            }
            else
            {
                client.HttpSend(TemplateActivator.Activate(this, client));
            }

            return true;
        }
    }
}
