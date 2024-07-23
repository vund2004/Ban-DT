namespace NET104_ASM.Models
{
    public class CartItem
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string HinhSp { get; set; }
        public int DonGiaSp { get; set; }
        public int SoLuongSp { get; set; }
        public int ThanhTienSp => DonGiaSp * SoLuongSp;
        public int TongTienSp=>ThanhTienSp+ThanhTienSp;

    }
}
