using RussianKawaiShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public class PhoneCallServiceImpl : PhoneCallService
    {
        public PhoneCall GetByID(int id)
        {
            List<PhoneCall> phoneCalls = DBConnector.manager.FastSelect<PhoneCall>(data => (data as PhoneCall).ID == id ? true : false);
            if (phoneCalls.Count > 0) return phoneCalls[0];
            return null;
        }

        public List<PhoneCall> GetAll()
        {
            return DBConnector.manager.FastSelect<PhoneCall>(data => true);
        }

        public PhoneCall Add(PhoneCall phoneCall)
        {
            if(phoneCall.Name.Length > 1 && phoneCall.Phone.Length > 1)
            {
                return this.GetByID(DBConnector.manager.InsertQueryReturn(phoneCall));
            }
            return null;
        }

        public void ChangeStatus(int status, int phoneCallID)
        {
            DBConnector.manager.FastUpdate<PhoneCall>(data => 
            {
                PhoneCall phoneCall = data as PhoneCall;
                if(phoneCall.ID == phoneCallID)
                {
                    phoneCall.Status = status;
                    return phoneCall;
                }
                return null;
            });
        }
    }
}
