﻿using RussianKawaiShop.Database;
using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;
using UpServer;

namespace RussianKawaiShop
{
    public class RussianKawaiShop : Page
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
            get { return "kawai-cosmetics.local;kawai-cosmetics.ru;www.kawai-cosmetics.ru"; }
        }
        public override uint CacheTime
        {
            get { return 0; }
        }
        public override ushort AccessLevel
        {
            get { return 0; }
        }

        private CartService cartService = new CartServiceImpl();

        public static void OnLoad()
        {
            DBConnector.manager = new UManager(new UBaseConnect(typeof(RussianKawaiDB), UBaseConnectType.Update));
            DBConnector.AutoCreate();
            
            Logger.ConsoleLog("Russian Kawai site loaded!");
        }

        public override bool PreInit(Client client)
        {
            if (cartService.GetCookie(client) == null)
            {
                client.SetCookie.Add("Cart", BaseFuncs.MD5(new Random().Next() + "CRT" + Environment.TickCount));
            }
            
            return true;

        }
    }
}
