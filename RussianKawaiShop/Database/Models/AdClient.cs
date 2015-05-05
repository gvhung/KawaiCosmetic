using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class AdClient : RussianKawaiDB
    {
        [UMaxLength(60)]
        public string IP;

        [UMaxLength(300)]
        public string Referer;

        public int Date;
    }
}
  