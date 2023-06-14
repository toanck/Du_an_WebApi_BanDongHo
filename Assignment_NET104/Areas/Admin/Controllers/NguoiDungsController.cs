using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Assignment_NET104.Services;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoiDungsController : Controller
    {
       private readonly ILogger<NguoiDungsController> _logger;
        private readonly INguoiDungServices nguoiDungServices;//Interface
        private readonly ShopWatchDbContext shopWatchDbContext;//Interface
        public NguoiDungsController(ILogger<NguoiDungsController> logger)
        {
            _logger = logger;
            nguoiDungServices = new NguoiDungServices();//new class
            shopWatchDbContext = new ShopWatchDbContext();

        }
        public IActionResult Index()
        {
             List<NguoiDung> nguoiDungs = nguoiDungServices.GetallNguoiDungs();
            return View("Index", nguoiDungs);
        }
        public IActionResult Details(Guid id)
        {

            NguoiDung NguoiDungs = nguoiDungServices.GetNguoiDungByid(id);
            return View(NguoiDungs);
        }
        public IActionResult Create()//hien thu view
        {
              ViewData["Vaitro"] = new SelectList(shopWatchDbContext.vaiTros, "Id", "TenVaiTro");
            return View();
        }
        [HttpPost]
        public IActionResult Create(NguoiDung NguoiDungs)// thuc hien chuc nang them
        {

            if (nguoiDungServices.CreateNguoiDung(NguoiDungs))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (nguoiDungServices.DeleteNguoiDung(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(NguoiDung NguoiDung) // thuc hien viec sua 
        {
            if (nguoiDungServices.UpdateNguoiDung(NguoiDung))
            {
                return RedirectToAction("Index");
            }
            return View(NguoiDung);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            NguoiDung NguoiDung = nguoiDungServices.GetNguoiDungByid(id);
            return View(NguoiDung);
        }
    }
}
