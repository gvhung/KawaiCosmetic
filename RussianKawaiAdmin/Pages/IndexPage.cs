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
            Hashtable data = new Hashtable();
            List<RussianKawaiShop.Order> orders = orderService.GetByStatus(1).OrderBy(olist => olist.ID * -1).ToList();
            data.Add("Orders", orders);
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
