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
    class AddPhoneCall : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/sys/add.phone.call/"; }
        }
        public override string TemplateAddr
        {
            get { return "sys.AddPhoneCall.html"; }
        }

        private PhoneCallService phoneCallService = new PhoneCallServiceImpl();

        public override bool Init(Client client)
        {
            if(client.ConnType == ConnectionType.WebSocket && client.WSData != null)
            {
                string[] WSData = Regex.Split(client.WSData, BaseFuncs.WSplit);
                string Action = WSData[0];

                if(Action == "AddPhoneCall" && WSData.Length == 4)
                {
                    PhoneCall phoneCall = new PhoneCall();
                    phoneCall.Name = WSData[1];
                    phoneCall.Phone = WSData[2];
                    phoneCall.Comment = WSData[3];

                    if(phoneCallService.Add(phoneCall) != null)
                    {
                        Logger.ConsoleLog("Added new phone call: " + phoneCall.Phone, ConsoleColor.Yellow);
                    }
                }
            }
            else
            {
                BaseFuncs.Show404(client);
            }
            return false;
        }
    }
}
