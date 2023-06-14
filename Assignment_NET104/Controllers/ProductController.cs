using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Assignment_NET104.IServices;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.CodeAnalysis;


namespace Assignment_NET104.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ISanPhamServices sanPhamServices;
        private readonly ShopWatchDbContext _shopWatchDbContext;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            sanPhamServices = new SanPhamServices();
            _shopWatchDbContext = new ShopWatchDbContext();
        }
        public IActionResult Product()
        {
            var list = sanPhamServices.GetallSanPhams();
            ViewBag.listSanPham = list.ToList();
            return View();
        }
        public ActionResult  SanPhamDetails(Guid id)
        {
            
            SanPham sanPham = sanPhamServices.GetSanPhamByid(id);
                return View(sanPham);
          
        }
    }
}
