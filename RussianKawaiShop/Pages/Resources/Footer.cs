﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop.Pages.Resources
{
    class Footer : RussianKawaiShop
    {
        public override string TemplateAddr
        {
            get { return "Resources.Footer.html"; }
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
