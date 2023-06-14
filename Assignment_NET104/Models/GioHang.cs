using Assignment_NET104.Models.entity;

namespace Assignment_NET104.Models
{
    public class GioHang: EntityBase
    {
       
        public Guid IdNguoiDung { get; set; }
        public Guid IdSp { get; set; }
        public int Soluong { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
