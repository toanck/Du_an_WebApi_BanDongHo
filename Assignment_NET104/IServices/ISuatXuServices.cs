using Assignment_NET104.Models;
namespace Assignment_NET104.IServices
{
    public interface ISuatXuServices
    {
        //cac phuong thuc lay sp
        public List<SuatXu> GetallSuatXus();
        public SuatXu GetSuatXuByid(Guid id);
        public List<SuatXu> GetSuatXuByName(string name);
        // phuong thuc them
        public bool CreateSuatXu(SuatXu g);
        // phuong thuc sua
        public bool UpdateSuatXu(SuatXu g);
        // phuong thuc xoa
        public bool DeleteSuatXu(Guid id);
    }
}
