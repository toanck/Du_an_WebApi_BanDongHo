using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class HoaDonServices:IHoaDonServices
    {
        ShopWatchDbContext Context;
        public HoaDonServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateHoaDon(HoaDon p)
        {
            try
            {
                Context.hoaDons.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDon(Guid id)
        {
            try
            {
                var HoaDon = Context.hoaDons.Find(id);
                Context.hoaDons.Remove(HoaDon);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<HoaDon> GetHoaDonByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<HoaDon> GetallHoaDons()
        {

            return Context.hoaDons.ToList();// lay tat ca cac san pham
        }

        public HoaDon GetHoaDonByid(Guid id)
        {
            return Context.hoaDons.FirstOrDefault(p => p.id == id);
        }

        public bool UpdateHoaDon(HoaDon p)
        {
            try
            {
                var HoaDon = Context.hoaDons.Find(p.id);
                HoaDon.IdNguoiDung = p.IdNguoiDung;
                HoaDon.CreateDate = p.CreateDate;
                HoaDon.TrangThai = p.TrangThai;
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

