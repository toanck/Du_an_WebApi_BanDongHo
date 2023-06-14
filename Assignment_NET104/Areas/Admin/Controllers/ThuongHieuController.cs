using Microsoft.AspNetCore.Mvc;
using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Assignment_NET104.Services;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThuongHieuController : Controller
    {
        private readonly ILogger<ThuongHieuController> _logger;
        private readonly IThuongHieuServices thuongHieuServices;//Interface
        public ThuongHieuController(ILogger<ThuongHieuController> logger)
        {
            _logger = logger;
            thuongHieuServices = new ThuongHieuServices();//new class

        }
        public IActionResult Index()
        {
            List<ThuongHieu> thuongHieus = thuongHieuServices.GetallThuongHieus();
            return View("Index", thuongHieus);
        }
        public IActionResult Details(Guid id)
        {

            ThuongHieu thuongHieus = thuongHieuServices.GetThuongHieuByid(id);
            return View(thuongHieus);
        }
        public IActionResult Create()//hien thu view
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ThuongHieu thuongHieus)// thuc hien chuc nang them
        {

            if (thuongHieuServices.CreateThuongHieu(thuongHieus))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (thuongHieuServices.DeleteThuongHieu(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(ThuongHieu ThuongHieu) // thuc hien viec sua 
        {
            if (thuongHieuServices.UpdateThuongHieu(ThuongHieu))
            {
                return RedirectToAction("Index");
            }
            return View(ThuongHieu);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            ThuongHieu ThuongHieu = thuongHieuServices.GetThuongHieuByid(id);
            return View(ThuongHieu);
        }
    }
}
