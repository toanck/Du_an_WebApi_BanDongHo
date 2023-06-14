using Assignment_NET104.Models;
using Assignment_NET104.IServices;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Assignment_NET104.Areas.Admin.Models;
using Assignment_NET104.Commom;
using Newtonsoft.Json;
//using Assignment_NET104.Migrations;

namespace Assignment_NET104.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamServices sanPhamServices;
        private readonly INguoiDungServices nguoiDungServices;//Interface
        private readonly ShopWatchDbContext shopWatchDbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            sanPhamServices = new SanPhamServices();//new class
             nguoiDungServices = new NguoiDungServices();//new class
            shopWatchDbContext = new ShopWatchDbContext();
        }

        public IActionResult Index()
        {
             var list = sanPhamServices.GetallSanPhams();
            ViewBag.listSanPham = list.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult DangNhap(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = nguoiDungServices.Login(model.TenDangNhap, model.MatKhau);
                if (result == 1)
                {
                    var user = nguoiDungServices.getLogin(model.TenDangNhap);
                    var session = new UserLogin();
                    session.TenDangNhap = user.TenDangNhap;
                    session.Id = user.Id;
                    session.Ten = user.TenNguoiDung;
                    session.email = user.Email;
                    HttpContext.Session.SetString(SessionEx.USER_SESSION, JsonConvert.SerializeObject(session));
                    var sessionJson = HttpContext.Session.GetString(SessionEx.USER_SESSION);
                    var session2 = JsonConvert.DeserializeObject<UserLogin>(sessionJson);
                    string jsonSession = HttpContext.Session.GetString(SessionEx.USER_SESSION);
                    
                    return RedirectToAction("Index", "home");
                }
                if (result == 2)
                {
                    var user = nguoiDungServices.getLogin(model.TenDangNhap);
                    var session = new UserLogin();
                    session.TenDangNhap = user.TenDangNhap;
                    session.Id = user.Id;
                    session.Ten = user.TenNguoiDung;
                    session.email = user.Email;
                    HttpContext.Session.SetString(SessionEx.USER_SESSION, JsonConvert.SerializeObject(session));
                    var sessionJson = HttpContext.Session.GetString(SessionEx.USER_SESSION);
                    var session2 = JsonConvert.DeserializeObject<UserLogin>(sessionJson);
                    return Redirect("https://localhost:7082/Admin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản chua được kích hoạt vui lòng hiên hệ admin ");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng vui lòng kiểm tra lại ");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại ");
                }
            }
            return View();
        }
    }
    }
