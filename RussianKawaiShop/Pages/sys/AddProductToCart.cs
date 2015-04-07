using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    class AddProductToCart : RussianKawaiShop
    {
        public override CacheLevel CacheLevel
        {
            get { return CacheLevel.BrowserCache; }
        }
        public override string TemplateAddr
        {
            get { return "sys.AddProductToCart.html"; }
        }
        public override bool FilterBefore
        {
            get { return false; }
        }
        public override bool FilterAfter
        {
            get { return false; }
        }

    }
}
