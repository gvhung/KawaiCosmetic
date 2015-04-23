using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class IndexPage : RussianKawaiShop
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

        public override bool Init(Client client)
        {
            if(client.GetParam("ad") == "woman_ru")
            {
                WebSocket.AD_WOMAN_RU++;
                client.Redirect("/");
            }
            Hashtable data = new Hashtable();
            data.Add("menuActive", "main");
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
