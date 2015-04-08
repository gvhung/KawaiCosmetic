using RussianKawaiShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiPartner
{
    public class RussianKawaiPartner : Page
    {
        public override CacheLevel CacheLevel
        {
            get { return CacheLevel.NoCache; }
        }
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return null; }
        }
        public override bool FilterBefore
        {
            get { return true; }
        }
        public override bool FilterAfter
        {
            get { return false; }
        }
        public override bool EnableHooking
        {
            get { return false; }
        }
        public override string TemplateAddr
        {
            get { return ""; }
        }
        public override string FaviconName
        {
            get { return "upserv.ico"; }
        }
        public override string Host
        {
            get { return "partner.kawai-cosmetic.local;partner.kawai-cosmetics.ru;www.partner.kawai-cosmetics.ru;partner.kawai-cosmetic.ru;www.partner.kawai-cosmetic.ru"; }
        }
        public override uint CacheTime
        {
            get { return 0; }
        }
        public override ushort AccessLevel
        {
            get { return 0; }
        }

        private PartnerService partnerService = new PartnerServiceImpl();
        public static void OnLoad()
        {
            Logger.ConsoleLog("Russian Kawai Partner site loaded!");
        }

        public override bool PreInit(Client client)
        {
            if (this.AccessLevel > 0 && partnerService.GetCurrentPartner(client) == null)
            {
                client.Redirect("/login/");
                return false;
            }
            //Logger.ConsoleLog(partnerService.GetCurrentPartner(client).Name);
            return true;
        }
    }
}
