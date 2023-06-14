using Assignment_NET104.Models;

namespace Assignment_NET104.IServices
{
    public interface IVaiTroServices
    {
        //cac phuong thuc lay sp
        public List<VaiTro> GetallVaiTros();
        public VaiTro GetVaiTroByid(Guid id);
        public List<VaiTro> GetVaiTroByName(string name);
        // phuong thuc them
        public bool CreateVaiTro(VaiTro g);
        // phuong thuc sua
        public bool UpdateVaiTro(VaiTro g);
        // phuong thuc xoa
        public bool DeleteVaiTro(Guid id);
    }
}
