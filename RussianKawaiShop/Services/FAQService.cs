using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public interface FAQService
    {
        FAQ GetByID(int id);
        List<FAQ> GetAll();
        void Edit(FAQ faq);
        FAQ Create(FAQ faq);
    }
}
