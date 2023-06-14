using Assignment_NET104.Models;

namespace Assignment_NET104.IServices
{
    public interface IGioHangServices
    {
        //cac phuong thuc lay sp
        public  List<GioHang> GetallGioHangs();
        public  GioHang GetGioHangByid(Guid id);
        public List<GioHang> GetGioHangByName(string name);
        // phuong thuc them
        public bool CreateGioHang(GioHang g);
        // phuong thuc sua
        public  bool UpdateGioHang(GioHang g);
        // phuong thuc xoa
        public bool DeleteGioHang(Guid id);
        public Task<List<GioHang>> GetAllAsync();
        public Task<GioHang> GetByIdAsync(Guid idProduct, Guid idUser);
        public Task<bool> AddAsync(GioHang obj);
        public Task<bool> UpdateAsync(Guid idProduct, Guid idUser, GioHang obj);
        public Task<bool> RemoveAsync(Guid idProduct, Guid idUser);
        public Task<List<GioHang>> GetAllOfUserAsync(Guid idUser);
        
    }
}
