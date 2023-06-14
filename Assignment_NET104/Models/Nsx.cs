namespace Assignment_NET104.Models
{
    public class Nsx
    {
        public Guid Id { get; set; }
        public string TenNxs { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
