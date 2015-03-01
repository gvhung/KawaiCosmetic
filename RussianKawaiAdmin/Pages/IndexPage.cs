using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages
{
    class IndexPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/"; }
        }
        public override string TemplateAddr
        {
            get { return "Orders.html"; }
        }
        private RussianKawaiShop.OrderService orderService = new RussianKawaiShop.OrderServiceImpl();

        public override bool Init(Client client)
        {
            int orderID, orderStatus;
            if (client.GetParam("order_id") != null && int.TryParse(client.GetParam("order_id"), out orderID) && client.GetParam("order_status") != null && int.TryParse(client.GetParam("order_status"), out orderStatus))
            {
                orderService.ChangeStatus(orderStatus, orderService.GetByID(orderID));
            }

            Hashtable data = new Hashtable();
            List<RussianKawaiShop.Order> orders = orderService.GetByStatus(1).OrderBy(olist => olist.ID * -1).ToList();
            List<RussianKawaiShop.Order> SentOrders = orderService.GetByStatus(2).OrderBy(olist => olist.ID * -1).ToList();

            data.Add("Orders", orders);
            data.Add("SentOrders", SentOrders);
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
