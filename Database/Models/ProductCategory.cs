using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpBase;

namespace RussianKawaiShop.Database.Models
{
    public class ProductCategory : RussianKawaiDB
    {
        [UMaxLength(100)]
        public string Name;
    }
}
