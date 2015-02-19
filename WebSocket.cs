﻿using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
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

        private CartService cartService = new CartServiceImpl();
        private ProductColorService productColorService = new ProductColorServiceImpl();
        public override bool Init(Client client)
        {
            if(client.WSData != null)
            {
                string[] WSData = Regex.Split(client.WSData, BaseFuncs.WSplit);
                string Action = WSData[0];

                if (Action == "AddProductToCartAction")
                {
                    int productId, num, productColorId;

                    if (int.TryParse(WSData[1], out productId) && int.TryParse(WSData[2], out num) && int.TryParse(WSData[1], out productId) && int.TryParse(WSData[3], out productColorId))
                    {
                        cartService.AddProduct(productId, num, cartService.GetCookie(client), productColorId);
                        client.SendWebsocket("CountItemsInCartAction" + BaseFuncs.WSplit + cartService.CountProductsNum(cartService.GetCookie(client)));
                    }
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
