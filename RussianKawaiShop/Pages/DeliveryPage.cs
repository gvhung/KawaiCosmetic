﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Pages
{
    class DeliveryPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/delivery/"; }
        }
        public override string TemplateAddr
        {
            get { return "Delivery.html"; }
        }

        public override bool Init(Client client)
        {
            Hashtable data = new Hashtable();
            data.Add("menuActive", "delivery");
            client.HttpSend(TemplateActivator.Activate(this, client, data));
            return true;
        }
    }
}
