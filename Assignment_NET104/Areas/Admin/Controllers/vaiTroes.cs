using Assignment_NET104.IServices;
using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class vaiTroes : Controller
    {
        private readonly ILogger<vaiTroes> _logger;
        private readonly IVaiTroServices vaiTroServices;//Interface

        public vaiTroes(ILogger<vaiTroes> logger)
        {
            _logger = logger;
            vaiTroServices = new VaiTroServices();//new class
        }
        public IActionResult Index()
        {
           List<VaiTro> vaiTros = vaiTroServices.GetallVaiTros();
            return View("Index", vaiTros);
        }
        public IActionResult Details(Guid id)
        {

            VaiTro vaiTro = vaiTroServices.GetVaiTroByid(id);
            return View(vaiTro);
        }
        public IActionResult Create()//hien thu view
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VaiTro vaiTro)// thuc hien chuc nang them
        {

            if (vaiTroServices.CreateVaiTro(vaiTro))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (vaiTroServices.DeleteVaiTro(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(VaiTro vaiTro) // thuc hien viec sua 
        {
            if (vaiTroServices.UpdateVaiTro(vaiTro))
            {
                return RedirectToAction("Index");
            }
            return View(vaiTro);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            VaiTro vaiTro = vaiTroServices.GetVaiTroByid(id);
            return View(vaiTro);
        }
    }
}
