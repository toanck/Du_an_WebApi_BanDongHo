using Assignment_NET104.IServices;
using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonChiTietController : Controller
    {
        
        private readonly ILogger<HoaDonChiTietController> _logger;
        private readonly IHoaDonChiTietServices hoaDonChiTietServices;//Interface

        public HoaDonChiTietController(ILogger<HoaDonChiTietController> logger)
        {
            _logger = logger;
            hoaDonChiTietServices = new HoaDonChiTietServices();//new class
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChapNhapThanhToan(Guid id)
        {
            if (hoaDonChiTietServices.DeleteHoaDonChiTiet(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult TuChoiThanhToan()
        {
            return View();
        }
    }
}
