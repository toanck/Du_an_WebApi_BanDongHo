using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class VaiTroServices : IVaiTroServices
    {
        ShopWatchDbContext Context;
        public VaiTroServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateVaiTro(VaiTro p)
        {
            try
            {
                Context.vaiTros.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteVaiTro(Guid id)
        {
            try
            {
                var VaiTro = Context.vaiTros.Find(id);
                Context.vaiTros.Remove(VaiTro);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<VaiTro> GetVaiTroByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<VaiTro> GetallVaiTros()
        {

            return Context.vaiTros.ToList();
        }

        public VaiTro GetVaiTroByid(Guid id)
        {
            return Context.vaiTros.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateVaiTro(VaiTro p)
        {
            try
            {   
                var VaiTro = Context.vaiTros.Find(p.Id);

                VaiTro.Id = p.Id;
                VaiTro.TenVaiTro = p.TenVaiTro;
                VaiTro.MieuTa = p.MieuTa;
                VaiTro.TrangThai = p.TrangThai;
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

