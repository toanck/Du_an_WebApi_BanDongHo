using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET104.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        ShopWatchDbContext Context;
        public SanPhamServices()
        {
            Context = new ShopWatchDbContext();
        }
        public bool CreateSanPham(SanPham p)
        {
            try
            {
                Context.sanPhams.Add(p);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSanPham(Guid id)
        {
            try
            {
                var SanPham = Context.sanPhams.Find(id);
                Context.sanPhams.Remove(SanPham);
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SanPham> GetSanPhamByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<SanPham> GetallSanPhams()
        {

            return Context.sanPhams.ToList();// lay tat ca cac san pham
        }

        public SanPham GetSanPhamByid(Guid id)
        {
            return Context.sanPhams.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateSanPham(SanPham p)
        {
            try
            {
                var SanPham = Context.sanPhams.Find(p.Id);
                SanPham.TenSp = p.TenSp;
                SanPham.IdThuongHieu = p.IdThuongHieu;
                SanPham.GiaSanPham = p.GiaSanPham;
                SanPham.SlTon = p.SlTon;
                SanPham.GioiTinh = p.GioiTinh;
                SanPham.IdXuatSu = p.IdXuatSu;
                SanPham.IdLoaiMay = p.IdLoaiMay;
                SanPham.IdNsx = p.IdNsx;
                SanPham.ThoiGianBaoHanh = p.ThoiGianBaoHanh;
                SanPham.MieuTa = p.MieuTa;
                SanPham.HinhAnh = p.HinhAnh;
                Context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
         public async Task<List<SanPham>> GetAllAsync()
        {
            var list = await Context.sanPhams.ToListAsync();

            return list;
        }
    }
}

