using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiShop
{
    public class EmailUtil
    {
        public static void Send(string email, string theme, string text)
        {
            BaseFuncs.SendEMail("nktbamba", "nktbamba@gmail.com", "De7828gDq1ws99772j1bbcgm", email, theme, text);
        }
    }
}
