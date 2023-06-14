using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface INguoiDungServices
    {
        //cac phuong thuc lay sp
        public List<NguoiDung> GetallNguoiDungs();
        public NguoiDung GetNguoiDungByid(Guid id);
        public NguoiDung getLogin(string Username);
        public List<NguoiDung> GetNguoiDungByName(string name);
        public int Login(string usermane, string pass);
        // phuong thuc them
        public bool CreateNguoiDung(NguoiDung g);
        // phuong thuc sua
        public bool UpdateNguoiDung(NguoiDung g);
        // phuong thuc xoa
        public bool DeleteNguoiDung(Guid id);
    }
}
