using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class Ad : RussianKawaiDB
    {
        [UMaxLength(100)]
        public string Name;

        public int Clicks = 0;

        [UMaxLength(100)]
        public string UniqueKey;
    }
}
