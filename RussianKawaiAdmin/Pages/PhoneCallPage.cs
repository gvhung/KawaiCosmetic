using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages
{
    class PhoneCallPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/phone.calls/"; }
        }
        public override string TemplateAddr
        {
            get { return "PhoneCall.html"; }
        }

        public override bool Init(Client client)
        {
            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}