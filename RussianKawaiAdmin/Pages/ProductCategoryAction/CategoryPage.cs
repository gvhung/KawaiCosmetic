using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages
{
    class CategoryPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/product.category/"; }
        }
        public override string TemplateAddr
        {
            get { return "ProductCategory.List.html"; }
        }

        public override bool Init(Client client)
        {
            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
