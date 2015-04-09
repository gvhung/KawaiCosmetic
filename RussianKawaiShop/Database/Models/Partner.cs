using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class Partner : RussianKawaiDB
    {
        [UMaxLength(60)]
        public string Name;

        [UMaxLength(20)]
        public string Login;

        [UMaxLength(40)]
        public string Password;

        public int SalePercentage = 10;
        public int IncomePercentage = 5;

        [UMaxLength(30)]
        public string UniqueCode;

        [UMaxLength(50)]
        public string Email;

        [UMaxLength(50)]
        public string UserSession;

        public double Wallet = 0;
    }
}
