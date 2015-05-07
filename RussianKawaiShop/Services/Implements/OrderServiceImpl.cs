using RussianKawaiShop.Database;
using RussianKawaiShop.Database.Models;
using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using UpServer;

namespace RussianKawaiShop
{
    public class OrderServiceImpl : OrderService
    {
        private ProductService productService = new ProductServiceImpl();
        private CartService cartService = new CartServiceImpl();
        private PartnerService partnerService = new PartnerServiceImpl();
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

        public List<Order> GetAll()
        {
            return DBConnector.manager.FastSelect<Order>(data => true);
        }

        public List<Order> GetByStatus(int status)
        {
            return DBConnector.manager.FastSelect<Order>(data => { 
                if((data as Order).Status == status)
                {
                    return true;
                }
                return false;
            });
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

        public List<Order> GetByPartner(int partnerID)
        {
            return DBConnector.manager.FastSelect<Order>(data => {
                Order order = data as Order;
                if (order.PartnerID == partnerID)
                {
                    return true;
                }
                return false;
            });
        }

        public List<Order> GetPartnerOrders(int partnerID)
        {
            return DBConnector.manager.FastSelect<Order>(data =>
            {
                Order order = data as Order;
                if (order.PartnerID == partnerID && order.Status > 0)
                {
                    return true;
                }
                return false;
            });
        }

        public List<Product> GetProducts(Order order)
        {
            List<Product> products = new List<Product>();
            foreach(string cart in order.Products.Split(';'))
            {
                int productID = int.Parse(cart.Split(':')[0]);
                Product product = productService.GetByID(productID).Clone();                
                if (cart.Split(':').Length > 1 && int.Parse(cart.Split(':')[2]) != 0)
                {
                    product.Color = int.Parse(cart.Split(':')[2]);
                }
                products.Add(product);
            }

            return products;
        }

        public int CountProductsNum(Product product, Order order)
        {
            foreach (string cart in order.Products.Split(';'))
            {
                int productID = int.Parse(cart.Split(':')[0]);
                int productColor = int.Parse(cart.Split(':')[2]);
                if (productID == product.ID && productColor == product.Color)
                {
                    return int.Parse(cart.Split(':')[1]);
                }
            }
            return 0;
        }

        public Order CreateOrder(Order order, Client client)
        {
            if(order.Name != null && order.Email != null && order.Country != null && order.City != null && order.Street != null
                && order.Home != null && order.Room != null)
            {
                order.Products = this.CreateProducts(cartService.GetByCookie(cartService.GetCookie(client)));
                order.UniqueCode = cartService.GetCookie(client) + "_ORDERED";

                if(order.PartnerID > 0)
                {
                    Partner partner = partnerService.GetByID(order.PartnerID);
                    if(partner != null)
                    {
                        order.PartnersPercentage = partner.IncomePercentage;
                        order.SalePercentage = partner.SalePercentage;
                        order.TotalCost = Math.Round(cartService.GetTotalCost(cartService.GetCookie(client)) - (cartService.GetTotalCost(cartService.GetCookie(client)) / 100 * partner.SalePercentage));
                    } 
                }
                else
                {
                    order.PartnerID = 0;
                    order.PartnersPercentage = 0;
                    order.SalePercentage = 0;
                    order.TotalCost = cartService.GetTotalCost(cartService.GetCookie(client));
                }

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
                result += cart.ProductID + ":" + cart.ProductNum + ":" + cart.ProductColor;
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

        public void ChangeEMS(string ems, Order order)
        {
            DBConnector.manager.FastUpdate<Order>(data =>
            {
                if ((data as Order).ID == order.ID)
                {
                    (data as Order).EMS = ems;
                    return data;
                }
                return null;
            });
        }

        public double CalculatePartnersIncome(Order order)
        {
            return this.CalculateTotalPriceWithoutSale(order) / 100 * order.PartnersPercentage;
        }

        public double CalculateTotalPriceWithoutSale(Order order)
        {
            return order.TotalCost + (order.TotalCost / 100 * order.SalePercentage);
        }
    }
}
