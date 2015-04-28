using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianKawaiShop
{
    public interface PhoneCallService
    {
        PhoneCall GetByID(int id);
        List<PhoneCall> GetAll();
        PhoneCall Add(PhoneCall phoneCall);
        void ChangeStatus(int status, int phoneCallID);
    }
}
