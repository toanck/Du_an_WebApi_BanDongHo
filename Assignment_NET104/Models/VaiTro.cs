namespace Assignment_NET104.Models
{
    public class VaiTro
    {
        public Guid Id { get; set; }
        public string TenVaiTro { get; set; }
        public string MieuTa { get; set; }
        public int TrangThai { get; set; }
        public  List<NguoiDung> nguoidung { get; set; }
    }
}
