//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
//using Xunit.Sdk;

namespace Assignment_NET104.Areas.Admin.Models
{
    public class LoginModel
    {
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage ="Không được để trống tài khoản này")]
        public string TenDangNhap { get; set; }
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage ="Không được để trống mật khẩu  này")]
        public string MatKhau { get; set; }
        public bool RemenberMe { get; set; }
    }
}
