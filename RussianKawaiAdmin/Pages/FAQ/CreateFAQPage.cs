using RussianKawaiShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages.Products
{
    class CreateFAQPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/faq/create/"; }
        }
        public override string TemplateAddr
        {
            get { return "FAQ.Create.html"; }
        }

        private FAQService faqService = new FAQServiceImpl();
        public override bool Init(Client client)
        {
            if (client.PostParam("AddFAQ") != null)
            {
                if (client.PostParam("question") != null && client.PostParam("answer") != null)
                {
                    RussianKawaiShop.FAQ fq = new RussianKawaiShop.FAQ();
                    fq.Question = client.PostParam("question");
                    fq.Answer = client.PostParam("answer");

                    RussianKawaiShop.FAQ faq = faqService.Create(fq);
                    if(faq != null)
                    {
                        client.Redirect("/faq/#pr_" + faq.ID);
                        Logger.ConsoleLog("Added new faq: " + faq.Question + " (ID: " + faq.ID + ")", ConsoleColor.Yellow);

                        return false;
                    }
                }
            }

            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
