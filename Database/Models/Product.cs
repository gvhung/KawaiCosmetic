using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class Product : RussianKawaiDB
    {
        [UMaxLength(50)]
        public string Name;

        [UMaxLength(50)]
        public string JPName;

        [UMaxLength(5000)]
        public string Description;

        public double Price;

        [UMaxLength(20)]
        public string HowMuch;

        public int CategoryId;

        [UMaxLength(200)]
        public string Images;

        [UMaxLength(20)]
        public string Volume;

        [UMaxLength(50)]
        public string ProductsInCategory;
    }
}
