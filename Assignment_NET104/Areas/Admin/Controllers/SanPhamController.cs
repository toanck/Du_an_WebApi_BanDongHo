using Assignment_NET104.IServices;
using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ILogger<SanPhamController> _logger;
        private readonly ISanPhamServices sanPhamServices;//Interface
        private readonly ShopWatchDbContext _shopWatchDbContext;
        public SanPhamController(ILogger<SanPhamController> logger)
        {
            _logger = logger;
            sanPhamServices = new SanPhamServices();//new class
            _shopWatchDbContext = new ShopWatchDbContext();

        }
        public async Task<IActionResult> Index(Guid id)
        {
            ViewData["ThuongHieu"] = new List<ThuongHieu>();
            List<SanPham> sanPhams = sanPhamServices.GetallSanPhams();
            return View("Index", sanPhams);
        }
        public IActionResult Details(Guid id)
        {
            SanPham sanPham = sanPhamServices.GetSanPhamByid(id);
            return View(sanPham);
        }
        public IActionResult Delete(Guid id)
        {
            if (sanPhamServices.DeleteSanPham(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham, IFormFile imageFile)//hien chuc năng tạo
        {

            if (imageFile != null && imageFile.Length > 0)// khong null va khong tronng
            {
                // tro toi thu muc wwwroot de lat nua thuc hien viec copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // thuc hien coppy anh vua chon sang thu muc moi sang wwwroot
                    imageFile.CopyTo(stream);
                }
                //gan lai gia tri cho desscription cua doi tuong bang file anh da duoc sao chep
                sanPham.HinhAnh = imageFile.FileName;

            }
            if (sanPhamServices.CreateSanPham(sanPham))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewData["ThuongHieu"] = new SelectList(_shopWatchDbContext.thuongHieus, "Id", "TenThuongHieu");
            ViewData["LoaiMay"] = new SelectList(_shopWatchDbContext.loaiMays, "Id", "TenLoaiMay");
            ViewData["Nsx"] = new SelectList(_shopWatchDbContext.Nsxes, "Id", "TenNxs");
            ViewData["SuatXu"] = new SelectList(_shopWatchDbContext.suatXus, "Id", "NoiXuatSu");
            return View();
        }

        public IActionResult Edit(SanPham sanPham, IFormFile imageFile)//chi thuc hien viec Sửa
        {

            if (imageFile != null && imageFile.Length > 0)// khong null va khong tronng
            {
                // tro toi thu muc wwwroot de lat nua thuc hien viec copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // thuc hien coppy anh vua chon sang thu muc moi sang wwwroot
                    imageFile.CopyTo(stream);
                }
                //gan lai gia tri cho desscription cua doi tuong bang file anh da duoc sao chep
                sanPham.HinhAnh = imageFile.FileName;

            }
            if (sanPhamServices.UpdateSanPham(sanPham))
            {
                return RedirectToAction("Index");
            }
            return View(sanPham);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)//thuc hien viec  hien ra form edit
        {
            ViewData["ThuongHieu"] = new SelectList(_shopWatchDbContext.thuongHieus, "Id", "TenThuongHieu");
            ViewData["LoaiMay"] = new SelectList(_shopWatchDbContext.loaiMays, "Id", "TenLoaiMay");
            ViewData["Nsx"] = new SelectList(_shopWatchDbContext.Nsxes, "Id", "TenNxs");
            ViewData["SuatXu"] = new SelectList(_shopWatchDbContext.suatXus, "Id", "NoiXuatSu");
            SanPham sanPham = sanPhamServices.GetSanPhamByid(id);
            return View(sanPham);

        }
    }
}
