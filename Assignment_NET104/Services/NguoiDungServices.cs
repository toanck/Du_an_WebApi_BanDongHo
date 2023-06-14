using Assignment_NET104.Models;
using Assignment_NET104.IServices;

namespace Assignment_NET104.Services
{
    public class NguoiDungServices:INguoiDungServices
    {
        ShopWatchDbContext Context;
        public NguoiDungServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateNguoiDung(NguoiDung p)
        {
            try
            {
                Context.nguoiDungs.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNguoiDung(Guid id)
        {
            try
            {
                var NguoiDung = Context.nguoiDungs.Find(id);
                Context.nguoiDungs.Remove(NguoiDung);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<NguoiDung> GetNguoiDungByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<NguoiDung> GetallNguoiDungs()
        {

             return Context.nguoiDungs.ToList();// Lấy tất cả các sản phẩm
        }

        public NguoiDung GetNguoiDungByid(Guid id)
        {
            return Context.nguoiDungs.FirstOrDefault(p => p.Id == id);
        } 
        public NguoiDung getLogin(string Username)
        {
            return Context.nguoiDungs.FirstOrDefault(p => p.TenDangNhap == Username);
        }
        public int Login(string Usermane , string pass)
        {
            var KH = Guid.Parse("9d6e18ed-3ee3-4d67-8cc9-b4619ec6f16a");
            var Admin = Guid.Parse("ba377b76-c67c-43b5-9255-0367bc24abaa");
            var user = Context.nguoiDungs.FirstOrDefault(x => x.TenDangNhap == Usermane);
            if (user == null)
            {
                return -2;
            }
            else
            {
                if (user.Idvaitro == KH && user.MatKhau == pass)
                {
                    return 1;
                }
                else if (user.Idvaitro == Admin && user.MatKhau == pass)
                {
                    return 2;
                }
                else  return -1;
            }
        }
        public bool UpdateNguoiDung(NguoiDung p)
        {
            try
            {
                var NguoiDung = Context.nguoiDungs.Find(p.Id);
                NguoiDung.Id = p.Id;
                NguoiDung.TenNguoiDung = p.TenNguoiDung;
                NguoiDung.Idvaitro = p.Idvaitro;
                
                NguoiDung.Email = p.Email;
                
                NguoiDung.SDT = p.SDT;
                NguoiDung.TrangThai = p.TrangThai;

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

