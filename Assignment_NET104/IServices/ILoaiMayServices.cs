using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface ILoaiMayServices
    {
        //cac phuong thuc lay sp
        public List<LoaiMay> GetallLoaiMays();
        public LoaiMay GetLoaiMayByid(Guid id);
        public List<LoaiMay> GetLoaiMayByName(string name);
        // phuong thuc them
        public bool CreateLoaiMay(LoaiMay g);
        // phuong thuc sua
        public bool UpdateLoaiMay(LoaiMay g);
        // phuong thuc xoa
        public bool DeleteLoaiMay(Guid id);
    }
}






































































