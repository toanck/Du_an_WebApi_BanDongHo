namespace Assignment_NET104.Models
{
    public class ThuongHieu
    {
        public Guid Id { get; set; }
        public string TenThuongHieu { get; set; }
        public string MoTa { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
