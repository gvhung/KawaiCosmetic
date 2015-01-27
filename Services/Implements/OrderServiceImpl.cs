using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using System.Collections.Generic;

namespace RussianKawaiShop.Services.Implements
{
    public class OrderServiceImpl : OrderService
    {
        private ProductService productService = new ProductServiceImpl();

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

        public Order CreateOrder(Order order)
        {
            if(order.Name != null && order.Email != null && order.Country != null && order.City != null && order.Region != null && order.Street != null
                && order.Home != null && order.Room != null)
            {
                return this.GetByID(DBConnector.manager.InsertQueryReturn(order));
            }

            return null;
        }

        public string CreateProducts(List<Cart> carts)
        {
            string result = "";
            foreach(Cart cart in carts)
            {
                result += cart.ProductID + ':' + cart.ProductNum;

                if(cart.Equals(carts[carts.Count - 1]))
                {
                    result += ";";
                }
            }

            return result;
        }
    }
}
