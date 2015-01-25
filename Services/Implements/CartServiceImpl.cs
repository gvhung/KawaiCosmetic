using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop.Services.Implements
{
    public class CartServiceImpl : CartService
    {
        private ProductService productService = new ProductServiceImpl();

        public Cart GetByCookies(string cookie)
        {
            List<Cart> cart = DBConnector.manager.FastSelect<Cart>(data => { 
                if((data as Cart).Cookie == cookie)
                {
                    return true;
                }

                return false;
            });

            if(cart.Count > 0)
            {
                return cart[0];
            }
            
            return null;
        }

        public bool AddProduct(int productID, int productNum, string cookie)
        {
            if(productService.GetByID(productID) != null)
            {
                Cart cart = this.GetByCookiesAndProduct(cookie, productID);

                if(cart == null)
                {
                    cart = new Cart();
                    cart.Cookie = cookie;
                    cart.ProductId = productID;
                    cart.ProductNum = this.NumberForAddProduct(cart.ProductNum, productNum);
                }
                else
                {
                    DBConnector.manager.FastUpdate<Cart>(data => {
                        Cart c = data as Cart;

                        if(c.ProductId == productID && c.Cookie == cookie)
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

        public Cart GetByCookiesAndProduct(string cookie, int productId)
        {
            List<Cart> cart = DBConnector.manager.FastSelect<Cart>(data =>
            {
                if ((data as Cart).Cookie == cookie && (data as Cart).ProductId == productId)
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
    }
}
