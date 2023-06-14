namespace Assignment_NET104.Models
{
    public class SuatXu
    {
        public Guid Id { get; set; }
        public string NoiXuatSu { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
