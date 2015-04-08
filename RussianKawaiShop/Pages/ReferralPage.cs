using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    public class ReferralPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/ref/"; }
        }

        private PartnerService partnerService = new PartnerServiceImpl();

        public override bool Init(Client client)
        {
            string rf = BaseFuncs.GetAdditionalURLArray(client.URL, URL)[0];
            if(rf != null)
            {
                Partner partner = partnerService.GetByLogin(rf);
                if (partner != null)
                {
                    partnerService.SavePartnerToCustomer(partner, client);
                }
            }
            client.Redirect("/");
            return false;
        }
    }
}
