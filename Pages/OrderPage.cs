using RussianKawaiShop.Database.Models;
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
    class OrderPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/order/"; }
        }
        public override string TemplateAddr
        {
            get { return "Order.html"; }
        }

        private OrderService orderService = new OrderServiceImpl();

        public override bool Init(Client client)
        {
            Order order = orderService.GetByUniqueCode(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0]);
            if (order != null)
            {
                Hashtable data = new Hashtable();
                data.Add("Order", order);
                client.HttpSend(TemplateActivator.Activate(this, client, data));
            }
            else
            {
                BaseFuncs.Show404(client);
            }
            return true;
        }
    }
}
