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
    public class LoaiMayController : Controller
    {
        private readonly ILogger<LoaiMayController> _logger;
        private readonly ILoaiMayServices loaiMayServices;//Interface
        public LoaiMayController(ILogger<LoaiMayController> logger)
        {
            _logger = logger;
            loaiMayServices = new LoaiMayServices();//new class

        }
        public IActionResult Index()
        {
            List<LoaiMay> LoaiMays = loaiMayServices.GetallLoaiMays();
            return View("Index", LoaiMays);
        }
        public IActionResult Details(Guid id)
        {

            LoaiMay LoaiMays = loaiMayServices.GetLoaiMayByid(id);
            return View(LoaiMays);
        }
        public IActionResult Create()//hien thu view
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoaiMay LoaiMays)// thuc hien chuc nang them
        {

            if (loaiMayServices.CreateLoaiMay(LoaiMays))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (loaiMayServices.DeleteLoaiMay(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(LoaiMay LoaiMay) // thuc hien viec sua 
        {
            if (loaiMayServices.UpdateLoaiMay(LoaiMay))
            {
                return RedirectToAction("Index");
            }
            return View(LoaiMay);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            LoaiMay LoaiMay = loaiMayServices.GetLoaiMayByid(id);
            return View(LoaiMay);
        }
    }
}
