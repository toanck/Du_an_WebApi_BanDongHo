using Assignment_NET104.Models;
using Assignment_NET104.IServices;


namespace Assignment_NET104.Services
{
    public class SuatXuServices:ISuatXuServices
    {
        ShopWatchDbContext Context;
        public SuatXuServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateSuatXu(SuatXu p)
        {
            try
            {
                Context.suatXus.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSuatXu(Guid id)
        {
            try
            {
                var SuatXu = Context.suatXus.Find(id);
                Context.suatXus.Remove(SuatXu);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SuatXu> GetSuatXuByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<SuatXu> GetallSuatXus()
        {

            return Context.suatXus.ToList();// lay tat ca cac san pham
        }

        public SuatXu GetSuatXuByid(Guid id)
        {
            return Context.suatXus.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateSuatXu(SuatXu p)
        {
            try
            {
                var SuatXu = Context.suatXus.Find(p.Id);

                
                SuatXu.NoiXuatSu = p.NoiXuatSu;
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

