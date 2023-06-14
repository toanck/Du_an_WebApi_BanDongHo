using System.Data;

namespace Assignment_NET104.Models
{
    public class NguoiDung
    {
        public Guid Id { get; set; }
        public Guid Idvaitro { get; set; }
        public string TenNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public string Email { get; set; }
        public int SDT { get; set; }
        public virtual VaiTro VaiTro{ get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
        public virtual GioHang? GioHang { get; set; }



    }
}
