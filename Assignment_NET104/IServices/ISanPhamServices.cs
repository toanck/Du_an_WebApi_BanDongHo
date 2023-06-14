using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface ISanPhamServices
    {
        //cac phuong thuc lay sp
        public List<SanPham> GetallSanPhams();
        public SanPham GetSanPhamByid(Guid id);
        public List<SanPham> GetSanPhamByName(string name);
        // phuong thuc them
        public bool CreateSanPham(SanPham g);
        // phuong thuc sua
        public bool UpdateSanPham(SanPham g);
        // phuong thuc xoa
        public bool DeleteSanPham(Guid id);
        public Task<List<SanPham>> GetAllAsync();
    }
}
