using Microsoft.AspNetCore.Mvc;
using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Assignment_NET104.Services;

namespace Assignment_NET104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuatXuController : Controller
    {
         private readonly ILogger<SuatXuController> _logger;
        private readonly ISuatXuServices suatXuServices;//Interface
        public SuatXuController(ILogger<SuatXuController> logger)
        {
            _logger = logger;
            suatXuServices = new SuatXuServices();//new class

        }
        public IActionResult Index()
        {
            List<SuatXu> SuatXus = suatXuServices.GetallSuatXus();
            return View("Index", SuatXus);
        }
        public IActionResult Details(Guid id)
        {

            SuatXu SuatXus = suatXuServices.GetSuatXuByid(id);
            return View(SuatXus);
        }
        public IActionResult Create()//hien thu view
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SuatXu SuatXus)// thuc hien chuc nang them
        {

            if (suatXuServices.CreateSuatXu(SuatXus))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            if (suatXuServices.DeleteSuatXu(id))// neu them thanh cong ve trang hien thi
            {
                return RedirectToAction("Index");
            }
            else return View("Index");
        }
        public IActionResult Edit(SuatXu SuatXu) // thuc hien viec sua 
        {
            if (suatXuServices.UpdateSuatXu(SuatXu))
            {
                return RedirectToAction("Index");
            }
            return View(SuatXu);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)// chi thuc  hien viec hien ra form edit
        {
            SuatXu SuatXu = suatXuServices.GetSuatXuByid(id);
            return View(SuatXu);
        }
    }
}
