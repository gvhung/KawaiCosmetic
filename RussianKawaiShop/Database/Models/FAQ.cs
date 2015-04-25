using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class FAQ : RussianKawaiDB
    {
        [UMaxLength(10000)]
        public string Question;
        [UMaxLength(10000)]
        public string Answer;
    }
}
