using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class FAQPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/faq/"; }
        }
        public override string TemplateAddr
        {
            get { return "FAQ.html"; }
        }

        public override bool Init(Client client)
        {
            Hashtable data = new Hashtable();
            data.Add("menuActive", "faq");
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
