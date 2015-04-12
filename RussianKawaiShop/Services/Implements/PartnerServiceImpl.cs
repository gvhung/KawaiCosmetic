using RussianKawaiShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    public class PartnerServiceImpl : PartnerService
    {
        public Partner CreatePartner(Partner partner)
        {
            if(partner.Name.Length > 0 && partner.Login != null && partner.Password.Length > 0 )
            {
                if(this.GetByLogin(partner.Login) == null)
                {
                    partner.Password = BaseFuncs.MD5(partner.Password);
                    return this.GetByID(DBConnector.manager.InsertQueryReturn(partner));
                }
            }

            return null;
        }

        public Partner GetByID(int id)
        {
            List<Partner> partner = DBConnector.manager.FastSelect<Partner>(data => (data as Partner).ID == id ? true : false);
            if (partner.Count > 0) return partner[0];
            return null;
        }

        public Partner GetByLogin(string Login)
        {
            List<Partner> partner = DBConnector.manager.FastSelect<Partner>(data => (data as Partner).Login.ToLower() == Login.ToLower() ? true : false);
            if (partner.Count > 0) return partner[0];
            return null;
        }

        public bool Authorize(string Login, string Pswd, Client client)
        {
            Partner partner = this.GetByLogin(Login);
            if(partner != null && partner.Password == BaseFuncs.MD5(Pswd))
            {
                partner.UserSession = this.GetRandomUserSession();
                client.SetCookie("PartnerSession", new Cookie(partner.UserSession));
                this.UpdateUserSession(partner.UserSession, partner.ID);
                return true;
            }
            return false;
        }

        public Partner GetByUserSession(string Session)
        {
            if (Session.Length > 0)
            {
                List<Partner> partner = DBConnector.manager.FastSelect<Partner>(data => (data as Partner).UserSession == Session ? true : false);
                if (partner.Count > 0) return partner[0];
            }
            return null;
        }
        public string GetClientSession(Client client)
        {
            return client.GetCookie("PartnerSession");
        }

        public Partner GetCurrentPartner(Client client)
        {
            if (this.GetClientSession(client) != null)
            {
                return this.GetByUserSession(this.GetClientSession(client));
            }
            return null;
        }

        public void SavePartnerToCustomer(Partner partner, Client client)
        {
            if(this.GetByLogin(partner.Login) != null)
            {
                //client.SetCookie["ref"] = partner.Login.ToUpper();
                client.SetCookie("ref", new Cookie(partner.Login.ToUpper()));
            }
        }

        public string GetCurstomersRef(Client client)
        {
            return client.GetCookie("ref");
        }

        public void ChangeWalletValue(double value, int partnerID)
        {
            DBConnector.manager.FastUpdate<Partner>(data => {
                Partner p = data as Partner;
                if(p.ID == partnerID)
                {
                    p.Wallet = value;
                    return p;
                }
                return null;
            });
        }

        private void UpdateUserSession(string Session, int partnerID)
        {
            DBConnector.manager.FastUpdate<Partner>(data =>
            {
                Partner part = data as Partner;
                if (part.ID == partnerID)
                {
                    part.UserSession = Session;
                    return part;
                }

                return null;
            });
        }

        private string GetRandomUserSession()
        {
            return BaseFuncs.MD5(new Random().Next() + "prtnr" + Environment.TickCount);
        }
    }
}
