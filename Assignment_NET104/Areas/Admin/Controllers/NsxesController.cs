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
    public class NsxesController : Controller
    {
         private readonly ILogger<NsxesController> _logger;
        private readonly INsxServices nsxServices;//Interface
        public NsxesController(ILogger<NsxesController> logger)
        {
            _logger = logger;
            nsxServices = new NsxServices();//new class

        }
        public IActionResult Index()
        {
            List<Nsx> Nsxs = nsxServices.GetallNsxs();
            return View("Index", Nsxs);
        }
        public IActionResult Details(Guid id)
        {

            Nsx Nsxs = nsxServices.GetNsxByid(id);
            return View(Nsxs);
        }
        public IActionResult Create()//hien thu view
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Nsx Nsxs)// thuc hien chuc nang them
        {

            if (nsxServices.CreateNsx(Nsxs))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (nsxServices.DeleteNsx(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(Nsx Nsx) // thuc hien viec sua 
        {
            if (nsxServices.UpdateNsx(Nsx))
            {
                return RedirectToAction("Index");
            }
            return View(Nsx);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            Nsx Nsx = nsxServices.GetNsxByid(id);
            return View(Nsx);
        }
    }
}
