namespace Assignment_NET104.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        public string TenNhanVien { get; set; }
        public string MatKhau { get; set; }
        public Guid VaiTro { get; set; }
        public string GioiTinh { get; set; }
        public string email { get; set; }
        public int SDT { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
    }
}
