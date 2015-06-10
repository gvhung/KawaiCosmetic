using RussianKawaiShop.Services;
using RussianKawaiShop.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;
using UpServer;

namespace RussianKawaiShop.Database
{
    public class DBConnector
    {
        public static UManager manager;

        public static void AutoCreate()
        {
            ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();

            string[] categories = { "DETOS EX", "Kawai Basic", "Coenzyme Q10", "Special Care", "Body Care & Hair Care", "Make Up Series", "Зеленый сок" };
            foreach (string category in categories)
            {
                if(productCategoryService.GetByName(category) == null)
                {
                    Logger.ConsoleLog("Added category: " + productCategoryService.CreateCategory(category).Name, ConsoleColor.Green);
                }
                
            }
        }
    }
}
