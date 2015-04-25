using UpBase;

namespace RussianKawaiShop
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


        [UMaxLength(20)]
        public string Index;

        [UMaxLength(50)]
        public string Phone;

        [UMaxLength(1500)]
        public string Comment;

        public double TotalCost;

        public int Status = 0;
        [UMaxLength(20)]
        public string EMS;

        public int PartnerID = 0;
        public int SalePercentage = 0;
        public int PartnersPercentage = 0;
    }
}
