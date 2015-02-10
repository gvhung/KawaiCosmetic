using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiAdmin.Pages.Recources
{
    class Head : RussianKawaiAdmin
    {
        public override string TemplateAddr
        {
            get { return "Resources.Head.html"; }
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
