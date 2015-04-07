using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin
{
    public class RussianKawaiAdmin : Page
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
            get { return "admin.kawai-cosmetic.local;admin.kawai-cosmetics.ru;www.admin.kawai-cosmetics.ru"; }
        }
        public override uint CacheTime
        {
            get { return 0; }
        }
        public override ushort AccessLevel
        {
            get { return 0; }
        }

        public static void OnLoad()
        {
            Logger.ConsoleLog("Russian Kawai admin site loaded!");
        }

        public override bool PreInit(Client client)
        {
            return true;

        }
    }
}
