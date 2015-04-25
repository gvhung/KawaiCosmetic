using RussianKawaiShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public class FAQServiceImpl : FAQService
    {
        public FAQ GetByID(int id)
        {
            List<FAQ> FAQ = DBConnector.manager.FastSelect<FAQ>(data => (data as FAQ).ID == id ? true : false);
            if (FAQ.Count > 0) return FAQ[0];
            return null;
        }

        public List<FAQ> GetAll()
        {
            return DBConnector.manager.FastSelect<FAQ>(data => true);
        }

        public void Edit(FAQ faq)
        {
            if(faq.Question != null && faq.Answer != null)
            {
                DBConnector.manager.FastUpdate<FAQ>(data => 
                {
                    if((data as FAQ).ID == faq.ID)
                    {
                        return faq;
                    }
                    return null;
                });
            }
        }

        public FAQ Create(FAQ faq)
        {
            if(faq.Question != null && faq.Answer != null)
            {
                return this.GetByID(DBConnector.manager.InsertQueryReturn(faq));
            }
            return null;
        }
    }
}
