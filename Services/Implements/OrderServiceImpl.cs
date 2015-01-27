using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System;
using System.Collections.Generic;
using UpServer;

namespace RussianKawaiShop.Services.Implements
{
    public class OrderServiceImpl : OrderService
    {
        private ProductService productService = new ProductServiceImpl();
        private CartService cartService = new CartServiceImpl();

        public Order GetByID(int id)
        {
            List<Order> orders = DBConnector.manager.FastSelect<Order>(data =>
            {
                if ((data as Order).ID == id)
                {
                    return true;
                }
                return false;
            });

            if (orders.Count > 0)
            {
                return orders[0];
            }

            return null;
        }

        public Order GetByUniqueCode(string unicode)
        {
            List<Order> orders = DBConnector.manager.FastSelect<Order>(data => { 
                if((data as Order).UniqueCode == unicode)
                {
                    return true;
                }
                return false;
            });

            if(orders.Count > 0)
            {
                return orders[0];
            }

            return null;
        }

        public List<Product> GetProducts(Order order)
        {
            List<Product> products = new List<Product>();
            foreach(string cart in order.Products.Split(';'))
            {
                int productID = int.Parse(cart.Split(':')[0]);
                products.Add(productService.GetByID(productID));
            }
            return products;
        }

        public int CountProductsNum(Product product, Order order)
        {
            foreach (string cart in order.Products.Split(';'))
            {
                int productID = int.Parse(cart.Split(':')[0]);
                if(productID == product.ID)
                {
                    return int.Parse(cart.Split(':')[1]);
                }
            }
            return 0;
        }

        public Order CreateOrder(Order order, Client client)
        {
            if(order.Name != null && order.Email != null && order.Country != null && order.City != null && order.Region != null && order.Street != null
                && order.Home != null && order.Room != null)
            {
                order.Products = this.CreateProducts(cartService.GetByCookie(cartService.GetCookie(client)));
                order.TotalCost = cartService.GetTotalCost(cartService.GetCookie(client));
                order.UniqueCode = cartService.GetCookie(client) + "_ORDERED";

                cartService.SetNewCookie(client);

                return this.GetByID(DBConnector.manager.InsertQueryReturn(order));
            }

            return null;
        }

        public string CreateProducts(List<Cart> carts)
        {
            string result = "";
            foreach(Cart cart in carts)
            {
                result += cart.ProductID + ":" + cart.ProductNum;
                if(!cart.Equals(carts[carts.Count - 1]))
                {
                    result += ";";
                }
            }
            return result;
        }

        public void ChangeStatus(int status, Order order)
        {
            DBConnector.manager.FastUpdate<Order>(data => {
                if((data as Order).ID == order.ID)
                {
                    (data as Order).Status = status;
                    return data;
                }
                return null;
            }, true);
        }
    }
}
