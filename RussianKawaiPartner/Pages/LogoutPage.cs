using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiPartner
{
    class LogoutPage : RussianKawaiPartner
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/logout/"; }
        }
        public override ushort AccessLevel
        {
            get { return 1; }
        }
        public override bool Init(Client client)
        {
            client.SetCookie("PartnerSession", new Cookie(""));
            client.Redirect("/");
            return false;
        }
    }
}
