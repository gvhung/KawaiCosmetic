using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class ProductColor : RussianKawaiDB
    {
        [UMaxLength(20)]
        public string Name;

        [UMaxLength(20)]
        public string RGB;
    }
}
