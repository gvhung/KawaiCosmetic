using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages.Errors
{
    class Error404 : RussianKawaiShop
    {
        public override CacheLevel CacheLevel
        {
            get { return CacheLevel.ResultCache; }
        }
        public override PageType PageType
        {
            get { return PageType.NotFound; }
        }
        public override string TemplateAddr
        {
            get { return "Errors.404.html"; }
        }
        public override bool Init(Client client)
        {
            string tosend = TemplateActivator.Activate(this, client);
            client.HttpSend(tosend);
            return true;
        }
    }
}
