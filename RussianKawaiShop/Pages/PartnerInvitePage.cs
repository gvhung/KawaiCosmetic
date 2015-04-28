using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class PartnerPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/partner/"; }
        }
        public override string TemplateAddr
        {
            get { return "PartnerInvite.html"; }
        }

        private PartnerService partnerService = new PartnerServiceImpl();
        public override bool Init(Client client)
        {
            if(client.PostParam("action") == "reg")
            {
                if(Registration(client.PostParam("login"), client.PostParam("password"), client.PostParam("name"), client.PostParam("email"), client))
                {
                    client.HttpSend("Молодец, регнулся.");
                    client.Redirect("http://partner." + client.Host);
                    return false;
                }
            }
            Hashtable data = new Hashtable();
            data.Add("menuActive", "partner");
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }

        private bool Registration(string login, string pswd, string name, string email, Client client)
        {
            Partner partner = new Partner();
            partner.Login = login;
            partner.Password = pswd;
            partner.Name = name;
            partner.Email = email;
            if (partnerService.CreatePartner(partner) != null)
            {
                partnerService.Authorize(partner.Login, pswd, client);
                return true;
            }
            return false;
        }
    }
}
