using UpBase;

namespace RussianKawaiShop.Database.Models
{
    public class Order : RussianKawaiDB
    {
        [UMaxLength(300)]
        public string UniqueCode;
        // id:num;id:num
        [UMaxLength(100)]
        public string Products;

        [UMaxLength(50)]
        public string Email;
        [UMaxLength(50)]
        public string Name;
        [UMaxLength(50)]
        public string Country;
        [UMaxLength(50)]
        public string City;
        [UMaxLength(50)]
        public string Region;
        [UMaxLength(50)]
        public string Street;
        [UMaxLength(50)]
        public string Home;
        [UMaxLength(50)]
        public string Room;

        [UMaxLength(50)]
        public string Phone;
    }
}
