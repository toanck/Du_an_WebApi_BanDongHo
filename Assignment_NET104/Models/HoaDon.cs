namespace Assignment_NET104.Models
{
    public class HoaDon
    {
        public Guid id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid IdNguoiDung { get; set; }
        public string TrangThai { get; set; }
        public List<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public NguoiDung nguoiDung { get; set; } 
    }
}
