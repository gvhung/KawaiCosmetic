using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    public interface PartnerService
    {
        Partner CreatePartner(Partner partner);
        Partner GetByID(int id);
        Partner GetByLogin(string Login);
        bool Authorize(string Login, string Pswd, Client client);
        Partner GetByUserSession(string Session);
        string GetClientSession(Client client);
        Partner GetCurrentPartner(Client client);
        void SavePartnerToCustomer(Partner partner, Client client);
    }
}
