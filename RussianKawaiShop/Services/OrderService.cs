using RussianKawaiShop.Database.Models;
using System.Collections.Generic;
using UpServer;

namespace RussianKawaiShop
{
    public interface OrderService
    {
        Order GetByID(int id);
        List<Order> GetAll();
        List<Order> GetByStatus(int status);
        List<Order> GetByPartner(int partnerID);
        List<Order> GetPartnerOrders(int partnerID);
        Order GetByUniqueCode(string unicode);
        List<Product> GetProducts(Order order);
        int CountProductsNum(Product product, Order order);
        Order CreateOrder(Order order, Client client);
        string CreateProducts(List<Cart> carts);
        void ChangeStatus(int status, Order order);
        void ChangeEMS(string ems, Order order);
        double CalculatePartnersIncome(Order order);
        double CalculateTotalPriceWithoutSale(Order order);
    }
}
