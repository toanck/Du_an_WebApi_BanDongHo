using Assignment_NET104.IServices;
using Assignment_NET104.Models;
using Assignment_NET104.Services;
using Microsoft.AspNetCore.Mvc;
using Assignment_NET104.Models;
using Newtonsoft.Json;

namespace Assignment_NET104.Extensions
{
    public static class SessionExtensions
    {

       // Đưa dữ liệu vào Session dưới dạng Json data
        public static void SetObjToJson(ISession session, string key, object value)
        {
            // Obj value là dữ liệu bạn muốn thêm vào Session
            // Chuyển đổi dữ liệu đó sang dạng JsonString
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        // Lấy và đưa dữ liệu từ session về dạng List<obj>
        public static List<SanPham> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // Đọc dữ liệu từ Session ở dạng chuỗi
            if (data != null)
            {
                var listObj = JsonConvert.DeserializeObject<List<SanPham>>(data);
                return listObj;
            }
            else return new List<SanPham>();
        }

        public static bool CheckProductInCart(Guid id, List<GioHang> cartProducts)
        {
            return cartProducts.Any(p => p.IdSp == id); // Kiểm tra xem có tồn tại sp đó trong GH chưa
        }

    }
}
