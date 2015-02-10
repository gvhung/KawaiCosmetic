using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages
{
    class OrderPage : RussianKawaiAdmin
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
        private RussianKawaiShop.OrderService orderService = new RussianKawaiShop.OrderServiceImpl();

        public override bool Init(Client client)
        {
            int orderID;
            if(int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0], out orderID))
            {
                RussianKawaiShop.Order order = orderService.GetByID(orderID);
                if(order != null && order.Status == 1)
                {
                    if (client.PostParam("AddEMS") != null && client.PostParam("ems") != null)
                    {
                        this.ChangeStatus(client.PostParam("ems"), order);
                        client.Redirect("/");

                        return false;
                    }
                    else
                    {
                        Hashtable data = new Hashtable();
                        data.Add("Order", order);
                        client.HttpSend(TemplateActivator.Activate(this, client, data));
                    }
                }
            }
            else
            {
                BaseFuncs.Show404(client);
            }
            
            return true;
        }

        private void ChangeStatus(string ems, RussianKawaiShop.Order order)
        {
            orderService.ChangeEMS(ems, order);
            orderService.ChangeStatus(2, order);
            Logger.ConsoleLog("Changed status for order: " + order.ID);
        }
    }
    
}
