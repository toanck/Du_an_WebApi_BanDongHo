using Assignment_NET104.Models;

namespace Assignment_NET104.Extensions
{
    public class SessionCart
    {
        List<GioHang> gioHangs = new List<GioHang>();
        public IEnumerable<GioHang> GioHangs()
        {
           return gioHangs;
        }
        public void Add(SanPham sanPham, int sl =1)
        {
            var item =  gioHangs.FirstOrDefault(c=>c.SanPham.Id == sanPham.Id);
            if (item == null)
            {
                gioHangs.Add(new GioHang
                {
                    SanPham = sanPham,
                    Soluong = sl
                });
            }
            else
            {
                item.Soluong += sl;
            }
        }
    }
}
