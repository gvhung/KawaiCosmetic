using RussianKawaiShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiPartner
{
    class IndexPage : RussianKawaiPartner
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
            get { return "Index.html"; }
        }
        public override ushort AccessLevel
        {
            get { return 1; }
        }

        private PartnerService partnerService = new PartnerServiceImpl();
        private OrderService orderService = new OrderServiceImpl();
        public override bool Init(Client client)
        {
            Hashtable data = new Hashtable();
            data.Add("Partner", partnerService.GetCurrentPartner(client));
            data.Add("PartnerOrders", orderService.GetPartnerOrders(partnerService.GetCurrentPartner(client).ID));
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
