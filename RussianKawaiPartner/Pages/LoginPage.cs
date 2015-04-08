using RussianKawaiShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiPartner.Pages
{
    public class LoginPage : RussianKawaiPartner
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/login/"; }
        }
        public override string TemplateAddr
        {
            get { return "Login.html"; }
        }

        private PartnerService partnerService = new PartnerServiceImpl();

        public override bool Init(Client client)
        {
            if(client.PostParam("action") == "login")
            {
                if (this.Login(client.PostParam("login"), client.PostParam("password"), client))
                {
                    client.Redirect("/");
                    return false;
                }
            }

            Hashtable data = new Hashtable();
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }

        private bool Login(string login, string password, Client client)
        {
            if(login.Length > 0 && password.Length > 0)
            {
                return partnerService.Authorize(login, password, client);
            }
            return false;
        }
    }
}
