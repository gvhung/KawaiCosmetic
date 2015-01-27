using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop.Database.Models
{
    public class Cart : RussianKawaiDB
    {
        [UMaxLength(300)]
        public string UniqueCode;
        public int ProductID;
        public int ProductNum;
    }
}
