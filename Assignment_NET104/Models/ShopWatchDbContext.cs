using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Assignment_NET104.Models
{
    public class ShopWatchDbContext : DbContext
    {
        public ShopWatchDbContext() { }
        public ShopWatchDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public DbSet<LoaiMay> loaiMays { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }
        public DbSet<Nsx> Nsxes { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<SuatXu> suatXus { get; set; }
        public DbSet<ThuongHieu> thuongHieus { get; set; }
        public DbSet<VaiTro> vaiTros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JV9E5UC\SQLEXPRESS;Initial Catalog=ShopWatch;Persist Security Info=True;User ID=toanck;Password=123456789");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
