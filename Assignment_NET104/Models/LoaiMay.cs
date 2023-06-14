namespace Assignment_NET104.Models
{
    public class LoaiMay
    {
        public Guid Id { get; set; }
        public string TenLoaiMay { get; set; }
        public string MoTa { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
