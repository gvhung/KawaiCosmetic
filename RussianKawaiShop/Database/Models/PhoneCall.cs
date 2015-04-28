using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop
{
    public class PhoneCall : RussianKawaiDB
    {
        [UMaxLength(100)]
        public string Name;

        [UMaxLength(150)]
        public string Phone;

        [UMaxLength(500)]
        public string Comment;

        public int Status;
    }
}
