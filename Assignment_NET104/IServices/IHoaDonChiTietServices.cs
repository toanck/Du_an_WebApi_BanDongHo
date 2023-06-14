using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface IHoaDonChiTietServices
    {
        //cac phuong thuc lay sp
        public List<HoaDonChiTiet> GetallHoaDonChiTiets();
        public HoaDonChiTiet GetHoaDonChiTietByid(Guid id);
        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name);
        // phuong thuc them
        public bool CreateHoaDonChiTiet(HoaDonChiTiet g);
        // phuong thuc sua
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet g);
        // phuong thuc xoa
        public bool DeleteHoaDonChiTiet(Guid id);
    }
}
