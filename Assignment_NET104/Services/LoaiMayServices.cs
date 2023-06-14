using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class LoaiMayServices:ILoaiMayServices
    {
        ShopWatchDbContext Context;
        public LoaiMayServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateLoaiMay(LoaiMay p)
        {
            try
            {
                Context.loaiMays.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLoaiMay(Guid id)
        {
            try
            {
                var LoaiMay = Context.loaiMays.Find(id);
                Context.loaiMays.Remove(LoaiMay);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<LoaiMay> GetLoaiMayByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<LoaiMay> GetallLoaiMays()
        {

            return Context.loaiMays.ToList();// lay tat ca cac san pham
        }

        public LoaiMay GetLoaiMayByid(Guid id)
        {
            return Context.loaiMays.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateLoaiMay(LoaiMay p)
        {
            try
            {
                var LoaiMay = Context.loaiMays.Find(p.Id);

                
                LoaiMay.TenLoaiMay = p.TenLoaiMay;
                LoaiMay.MoTa = p.MoTa;
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

