using Assignment_NET104.Models;

namespace Assignment_NET104.IServices
{
    public interface IThuongHieuServices
    {
        //cac phuong thuc lay sp
        public List<ThuongHieu> GetallThuongHieus();
        public ThuongHieu GetThuongHieuByid(Guid id);
        public List<ThuongHieu> GetThuongHieuByName(string name);
        // phuong thuc them
        public bool CreateThuongHieu(ThuongHieu g);
        // phuong thuc sua
        public bool UpdateThuongHieu(ThuongHieu g);
        // phuong thuc xoa
        public bool DeleteThuongHieu(Guid id);
    }
}
