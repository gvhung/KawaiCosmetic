using UpServer;

namespace RussianKawaiShop.Pages
{
    public class RedirectPage : RussianKawaiShop
    {
        public override PageType PageType
        {
            get { return PageType.Once; }
        }
        public override string URL
        {
            get { return "/redirect/"; }
        }
        public override string TemplateAddr
        {
            get { return "Redirect.html"; }
        }

        public override bool Init(Client client)
        {
            client.HttpSend(TemplateActivator.Activate(this, client));
            return true;
        }
    }
}
