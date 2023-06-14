using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class HoaDonChiTietServices:IHoaDonChiTietServices
    {
        ShopWatchDbContext Context;
        public HoaDonChiTietServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                Context.hoaDonChiTiets.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var HoaDonChiTiet = Context.hoaDonChiTiets.Find(id);
                Context.hoaDonChiTiets.Remove(HoaDonChiTiet);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<HoaDonChiTiet> GetHoaDonChiTietByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<HoaDonChiTiet> GetallHoaDonChiTiets()
        {

            return Context.hoaDonChiTiets.ToList();// lay tat ca cac san pham
        }

        public HoaDonChiTiet GetHoaDonChiTietByid(Guid id)
        {
            return Context.hoaDonChiTiets.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                var HoaDonChiTiet = Context.hoaDonChiTiets.Find(p.Id);

                HoaDonChiTiet.IdSanPham = p.IdSanPham;
                HoaDonChiTiet.SLMua = p.SLMua;
                HoaDonChiTiet.GiaTien = p.SLMua;
                HoaDonChiTiet.NgayDat = p.NgayDat;
                HoaDonChiTiet.NgayGiao = p.NgayGiao;
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

