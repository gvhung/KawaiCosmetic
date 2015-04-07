using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    class WebSocket : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/ws/"; }
        }
        public override string TemplateAddr
        {
            get { return "ws.WebSocket.html"; }
        }
        public static int WSPeople = 0;
        public static int JSPeople = 0;
        public static int AD_WOMAN_RU = 0;

        public override bool Init(Client client)
        {
            client.HttpSend("WEBSOCKET:" + WSPeople + " // JAVASCRIPT: " + JSPeople + " // WOMAN_RU: " + AD_WOMAN_RU);
            return false;
        }

    }
}
