using System.Globalization;
using System.Net.Http.Headers;

namespace Assignment_NET104.Models
{
    public class SanPham: entity.EntityBase
    {
        public Guid Id { get; set; }
        public string TenSp { get; set; }
        public Guid IdThuongHieu { get; set; }
        public long GiaSanPham { get; set; }
        public int TrangThai { get; set; }
        public int SlTon { get; set; }
        public int GioiTinh { get; set; }
        public Guid IdXuatSu { get; set; }
        public Guid IdLoaiMay { get; set; }
        public Guid IdNsx { get; set; }
        public string ThoiGianBaoHanh { get; set; }
        public string MieuTa { get; set; }
        public string HinhAnh { get; set; }
        public virtual List<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public virtual ThuongHieu ThuongHieus { get; set; }
        public virtual SuatXu SuatXus { get; set; }
        public virtual LoaiMay LoaiMays { get; set; }
        public virtual Nsx Nsxes { get; set; }
        public string FormatNumber(long number)
        {
            // Sử dụng phương thức ToString() để định dạng số và trả về chuỗi
            return number.ToString("#,##0", new CultureInfo("vi-VN"));
        }
    }
}
