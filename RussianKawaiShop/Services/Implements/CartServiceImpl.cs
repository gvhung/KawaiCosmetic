﻿using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop.Services.Implements
{
    public class CartServiceImpl : CartService
    {
        private ProductService productService = new ProductServiceImpl();
        private ProductColorService productColorService = new ProductColorServiceImpl();

        public string GetCookie(Client client)
        {
            return client.GetCookie("Cart");
        }

        public string SetNewCookie(Client client)
        {
            string cookie = BaseFuncs.MD5(new Random().Next() + "CRT" + Environment.TickCount);
            //client.SetCookie.Add("Cart", cookie);
            client.SetCookie("Cart", new Cookie(cookie));
            return cookie;
        }

        public List<Cart> GetByCookie(string cookie)
        {
            List<Cart> cart = DBConnector.manager.FastSelect<Cart>(data => { 
                if((data as Cart).UniqueCode == cookie)
                {
                    return true;
                }

                return false;
            });

            return cart;
        }

        public bool AddProduct(int productID, int productNum, string cookie, int productColorId = 0)
        {
            if(productService.GetByID(productID) != null && productNum > 0)
            {
                if(productColorId != 0)
                {
                    if(productColorService.GetByID(productColorId) == null)
                    {
                        productColorId = 0;
                    }
                }

                Cart cart = this.GetByCookieAndProductID(cookie, productID, productColorId);

                if(cart == null)
                {
                    cart = new Cart();
                    cart.UniqueCode = cookie;
                    cart.ProductID = productID;
                    cart.ProductNum = this.NumberForAddProduct(cart.ProductNum, productNum);
                    cart.ProductColor = productColorId;
                    DBConnector.manager.InsertQuery(cart);
                }
                else
                {
                    DBConnector.manager.FastUpdate<Cart>(data => {
                        Cart c = data as Cart;

                        if (c.ProductID == productID && c.UniqueCode == cookie && c.ProductColor == productColorId)
                        {
                            c.ProductNum = this.NumberForAddProduct(c.ProductNum, productNum);
                        }

                        return null;
                    }, true);
                }

                return true;
            }

            return false;
        }

        private int NumberForAddProduct(int before, int add)
        {
            if((before + add) >= 10)
            {
                return 10;
            }
            return before + add;
        }

        public Cart GetByCookieAndProductID(string cookie, int productId, int productColorId = 0)
        {
            List<Cart> cart = DBConnector.manager.FastSelect<Cart>(data =>
            {
                if ((data as Cart).UniqueCode == cookie && (data as Cart).ProductID == productId && (data as Cart).ProductColor == productColorId)
                {
                    return true;
                }

                return false;
            });

            if (cart.Count > 0)
            {
                return cart[0];
            }

            return null;
        }

        public int CountProductsNum(string cookie)
        {
            int result = 0;
            foreach(Cart cart in this.GetByCookie(cookie))
            {
                result += cart.ProductNum;
            }
            return result;
        }

        public double GetTotalCost(List<Cart> carts)
        {
            double total = 0;
            foreach(Cart cart in carts)
            {
                total += cart.ProductNum * productService.GetPrice(cart.ProductID);
            }
            return total;
        }

        public double GetTotalCost(string cookie)
        {
            if(this.GetByCookie(cookie).Count > 0)
            {
                return this.GetTotalCost(this.GetByCookie(cookie));
            }

            return 0;
        }
    }
}
