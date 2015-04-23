using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class ProductCategory : RussianKawaiDB
    {
        [UMaxLength(100)]
        public string Name;

        [UMaxLength(2000)]
        public string Description;
    }
}
