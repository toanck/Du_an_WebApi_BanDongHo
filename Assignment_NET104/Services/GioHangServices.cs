using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET104.Services
{
    public class GioHangervices : IGioHangServices
    {
        private readonly ShopWatchDbContext Context;

        public GioHangervices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateGioHang(GioHang p)
        {
            try
            {
                Context.gioHangs.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHang(Guid id)
        {
            try
            {
                var GioHang = Context.gioHangs.Find(id);
                Context.gioHangs.Remove(GioHang);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GioHang> GetGioHangByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<GioHang> GetallGioHangs()
        {

            return Context.gioHangs.ToList(); ;// lay tat ca cac san pham
        }



        public bool UpdateGioHang(GioHang g)
        {
            try
            {


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }







        public GioHang GetGioHangByid(Guid id)
        {
            throw new NotImplementedException();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<bool> AddAsync(GioHang obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await Context.gioHangs.AddAsync(obj);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<GioHang>> GetAllAsync()
        {
            var list = await Context.gioHangs.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<List<GioHang>> GetAllOfUserAsync(Guid idUser)
        {
            var list = await Context.gioHangs.ToListAsync();
            if (list == null)
            {
                return new();
            }

            list = list.Where(c => c.IdNguoiDung == idUser && c.Status == 0).ToList();
            return list;
        }

        public async Task<GioHang> GetByIdAsync(Guid idProduct, Guid idUser)
        {
            var list = await Context.gioHangs.ToListAsync();
            var obj = list.FirstOrDefault(c => c.IdNguoiDung == idUser && c.IdSp == idProduct);
            if (obj == null)
            {
                return new GioHang();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid idProduct, Guid idUser)
        {
            try
            {
                var list = await Context.gioHangs.ToListAsync();
                var obj = list.FirstOrDefault(c => c.IdNguoiDung == idUser && c.IdSp == idProduct);
                obj.Status = 0;

                Context.gioHangs.Attach(obj);
                await Task.FromResult<GioHang>(Context.gioHangs.Update(obj).Entity);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idProduct, Guid idUser, GioHang obj)
        {
            try
            {
                var listObj = await Context.gioHangs.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.IdNguoiDung == idUser && c.IdSp == idProduct);

                objForUpdate.Soluong = obj.Soluong;
                objForUpdate.Status = obj.Status;

                Context.gioHangs.Update(objForUpdate);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////
    ///






}
