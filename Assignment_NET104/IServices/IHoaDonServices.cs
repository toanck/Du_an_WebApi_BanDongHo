using Assignment_NET104.Models;
using Assignment_NET104.IServices;

public interface IHoaDonServices
{
    //cac phuong thuc lay sp
    public List<HoaDon> GetallHoaDons();
    public HoaDon GetHoaDonByid(Guid id);
    public List<HoaDon> GetHoaDonByName(string name);
    
    // phuong thuc them
    public bool CreateHoaDon(HoaDon g);
    // phuong thuc sua
    public bool UpdateHoaDon(HoaDon g);
    // phuong thuc xoa
    public bool DeleteHoaDon(Guid id);
}
