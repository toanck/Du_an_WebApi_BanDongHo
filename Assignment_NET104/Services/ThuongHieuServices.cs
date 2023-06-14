using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class ThuongHieuServices:IThuongHieuServices
    {
        ShopWatchDbContext Context;
        public ThuongHieuServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateThuongHieu(ThuongHieu p)
        {
            try
            {
                Context.thuongHieus.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteThuongHieu(Guid id)
        {
            try
            {
                var ThuongHieu = Context.thuongHieus.Find(id);
                Context.thuongHieus.Remove(ThuongHieu);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ThuongHieu> GetThuongHieuByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<ThuongHieu> GetallThuongHieus()
        {

            return Context.thuongHieus.ToList();// lay tat ca cac san pham
        }

        public ThuongHieu GetThuongHieuByid(Guid id)
        {
            return Context.thuongHieus.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateThuongHieu(ThuongHieu p)
        {
            try
            {
                var ThuongHieu = Context.thuongHieus.Find(p.Id);

          
                ThuongHieu.TenThuongHieu = p.TenThuongHieu;
                ThuongHieu.MoTa = p.MoTa;
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

