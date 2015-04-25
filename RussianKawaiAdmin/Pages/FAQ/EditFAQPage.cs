using RussianKawaiShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages.Products
{
    class EditFAQPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/faq/edit/"; }
        }
        public override string TemplateAddr
        {
            get { return "FAQ.Edit.html"; }
        }

        private FAQService faqService = new FAQServiceImpl();
        public override bool Init(Client client)
        {
            int faqID;
            if (int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0], out faqID))
            {
                RussianKawaiShop.FAQ faq = faqService.GetByID(faqID);
                if (faq != null)
                {
                    Hashtable data = new Hashtable();

                    if (client.PostParam("EditFAQ") != null)
                    {
                        if (client.PostParam("question") != null && client.PostParam("answer") != null)
                        {
                            faq.Question = client.PostParam("question");
                            faq.Answer = client.PostParam("answer");
                            faqService.Edit(faq);

                            client.Redirect("/faq/#pr_" + faq.ID);
                            Logger.ConsoleLog("Edited faq: " + faq.Question + " (ID: " + faq.ID + ")", ConsoleColor.Yellow);

                            return false;
                        }
                    }
                    data.Add("FAQ", faq);
                    client.HttpSend(TemplateActivator.Activate(this, client, data));
                    return true;
                }  
            }


            BaseFuncs.Show404(client);
            return false;
        }
    }
}
