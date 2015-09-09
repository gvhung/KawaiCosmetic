using RussianKawaiShop.Database.Models;
using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Net;
using UpServer;

namespace RussianKawaiShop
{
    public class Robokassa : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/robokassa/"; }
        }

        private OrderService orderService = new OrderServiceImpl();
        private PartnerService partnerService = new PartnerServiceImpl();
        public override bool Init(Client client)
        {
            string Action = BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0];
            if (Action == "success")
            {
                client.Redirect("http://thegameslot.com/robokassa/success");
            }

            else if (Action == "result")
            {
                try
                {
                    string get = "?InvId=" + client.GetParam("InvId") + "&OutSum=" + client.GetParam("OutSum") + "&SignatureValue=" + client.GetParam("SignatureValue");
                    Logger.ConsoleLog("KAWAI get: " + get);
                    using (WebClient wc = new WebClient())
                    {
                        string res = wc.DownloadString("http://thegameslot.com/robokassa/result/" + get);
                        Logger.ConsoleLog("RESULT FROM GAMESLOT: " + res);
                        client.HttpSend(res);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Logger.ConsoleLog("ERROR ON KAWAI ROBO: " + ex, ConsoleColor.Red);
                }
            }


            /*
            string Action = BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0];
            Order order = this.CheckOrderByID(client.GetParam("InvId"));

            if(Action == "success")
            {
                if(order != null)
                {
                    client.Redirect("/order/" + order.UniqueCode);
                }
            }
            else if(Action == "result")
            {
                if (order != null && this.ResultCRC(client).Equals(client.GetParam("SignatureValue")))
                {
                    orderService.ChangeStatus(1, order);
                    if(order.PartnerID > 0)
                    {
                        Partner partner = partnerService.GetByID(order.PartnerID);
                        partnerService.ChangeWalletValue(partner.Wallet + orderService.CalculatePartnersIncome(order), order.PartnerID);
                    }
                    client.HttpSend("OK" + order.ID);
                }
            }
            */
            BaseFuncs.Show404(client);
            return true;
        }

        private Order CheckOrderByID(string InvId)
        {
            int orderID;
            if (int.TryParse(InvId, out orderID))
            {
                Order order = orderService.GetByID(orderID);
                if (order != null)
                {
                    return order;
                }
            }
            return null;
        }

        private string mrh_login = "KawaiCosmetics";

        public string GetPaymentURL(Order order)
        {
            string crc = this.SignatureValue(order);
            string attr = "?MrchLogin=" + this.mrh_login + "&OutSum=" + order.TotalCost.ToString() + ".00&InvId=" + order.ID + "&SignatureValue=" + crc;
            return "https://auth.robokassa.ru/Merchant/Index.aspx" + attr;
            //return "http://test.robokassa.ru/Index.aspx" + attr;
        }

        public string SignatureValue(Order order)
        {
            string mrh_pass1 = "12311974a";
            return BaseFuncs.MD5(this.mrh_login + ":" + order.TotalCost.ToString() + ".00:" + order.ID + ":" + mrh_pass1);
        }

        private string ResultCRC(Client client)
        {
            string crc = client.GetParam("OutSum") + ":" + client.GetParam("InvId") + ":" + "12311974b";
            Console.WriteLine(crc);
            return BaseFuncs.MD5(crc).ToUpper();
        }
    }
}
