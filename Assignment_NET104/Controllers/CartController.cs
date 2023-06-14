using Assignment_NET104.IServices;
using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    public class CartController : Controller
    {
        private readonly IGioHangServices gioHangServices;
        private readonly ISanPhamServices sanPhamServices;
        private readonly NguoiDungServices nguoiDungServices;
        private ShopWatchDbContext shopWatchDbContext;

        public CartController()
        {
            gioHangServices = new GioHangervices();
            sanPhamServices = new SanPhamServices();
            shopWatchDbContext = new ShopWatchDbContext();
            nguoiDungServices = new NguoiDungServices();
        }

        //public async Task<IActionResult> AddToCart(Guid idUser)
        //{
        //    //var idUser1 = nguoiDungServices.GetNguoiDungByid(idUser);
        //    idUser = Guid.Parse("98513859-0014-4b2c-1346-08db3dbf0574");
        //    //if (idUser == Guid.Empty)
        //    //{
        //    //    return RedirectToAction("AddToCart", "Home");
        //    //}

        //    var listCartDetails = await gioHangServices.GetAllAsync();
        //    ViewBag.listCartDetails = listCartDetails.Where(c => c.IdNguoiDung == idUser).ToList();
        //    ViewBag.listProduct = await sanPhamServices.GetAllAsync();

        //    return View();
        //}

        public async Task<IActionResult> Details(Guid idProduct, Guid idUser)
        {
            ViewBag.cartDetails = await gioHangServices.GetByIdAsync(idProduct, idUser);

            return View();
        }

        public async Task<IActionResult> Create(Guid idProduct, Guid idUser)
        {
            List<GioHang> cartDetails = await gioHangServices.GetAllAsync();

            GioHang obj = new()
            {
                IdNguoiDung = idUser,
                IdSp = idProduct,
                Soluong = 1
            };

            // Check sản phẩm đã có trong giỏ hàng hay chưa
            // Nếu có => Update +1 cho Amount
            // Nếu không => Create
            if (cartDetails.Any(c => c.IdNguoiDung == idUser && c.IdSp == idProduct))
            {
                // Update
                if (cartDetails.FirstOrDefault(c => c.IdNguoiDung == idUser && c.IdSp == idProduct).Soluong>0)
                {
                    obj.Soluong = cartDetails.FirstOrDefault(c => c.IdNguoiDung == idUser && c.IdSp == idProduct).Soluong + 1;
                }

                var resultUpdate = await gioHangServices.UpdateAsync(obj.IdSp, obj.IdNguoiDung, obj);

                if (resultUpdate)
                {
                    return RedirectToAction("AddToCart");
                }
            }
            else
            {
                var result = await gioHangServices.AddAsync(obj);

                if (result)
                {
                    return RedirectToAction("AddToCart");
                }
            }

            return RedirectToAction("AddToCart", "Home");
        }

        public async Task<IActionResult> Update(GioHang obj)
        {
            obj.IdNguoiDung = Guid.Parse("98513859-0014-4b2c-1346-08db3dbf0574");//////////////////////

            var result = await gioHangServices.UpdateAsync(obj.IdNguoiDung, obj.IdSp, obj);

            if (result)
            {
                return RedirectToAction("AddToCart");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid idProduct, Guid idUser)
        {
            var result = await gioHangServices.RemoveAsync(idProduct, idUser);

            return RedirectToAction("AddToCart", new { idUser = Guid.Empty });
        } 
        public async Task<IActionResult> AddToCart(Guid idUser)
        {
            //var idUser1 = nguoiDungServices.GetNguoiDungByid(idUser);
            idUser = Guid.Parse("98513859-0014-4b2c-1346-08db3dbf0574");
            //if (idUser == Guid.Empty)
            //{
            //    return RedirectToAction("AddToCart", "Home");
            //}
            var listCartDetails = await gioHangServices.GetAllAsync();
            ViewBag.listCartDetails = listCartDetails.Where(c => c.IdNguoiDung == idUser).ToList();
            ViewBag.listProduct = await sanPhamServices.GetAllAsync();

            return View();
        }
        
    }
}

