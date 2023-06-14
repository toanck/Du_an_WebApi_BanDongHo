using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class NsxServices:INsxServices
    {
        ShopWatchDbContext Context;
        public NsxServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateNsx(Nsx p)
        {
            try
            {
                Context.Nsxes.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNsx(Guid id)
        {
            try
            {
                var Nsx = Context.Nsxes.Find(id);
                Context.Nsxes.Remove(Nsx);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Nsx> GetNsxByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Nsx> GetallNsxs()
        {

            return Context.Nsxes.ToList();// lay tat ca cac san pham
        }

        public Nsx GetNsxByid(Guid id)
        {
            return Context.Nsxes.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateNsx(Nsx p)
        {
            try
            {
                var Nsx = Context.Nsxes.Find(p.Id);

               
                Nsx.TenNxs = p.TenNxs;
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

