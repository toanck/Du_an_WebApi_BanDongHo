using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface INsxServices
    {
        //cac phuong thuc lay sp
        public List<Nsx> GetallNsxs();
        public Nsx GetNsxByid(Guid id);
        public List<Nsx> GetNsxByName(string name);
        // phuong thuc them
        public bool CreateNsx(Nsx g);
        // phuong thuc sua
        public bool UpdateNsx(Nsx g);
        // phuong thuc xoa
        public bool DeleteNsx(Guid id);
    }
}
