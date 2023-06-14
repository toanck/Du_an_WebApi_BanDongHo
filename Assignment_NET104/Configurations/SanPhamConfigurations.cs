using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class SanPhamConfigurations : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            //builder.Property(c => c.Id).
            //    HasColumnName("id").IsRequired();
            //builder.Property(c => c.TenSp).HasColumnType("nvarchar(100)")
            //    .IsRequired();
            //builder.Property(c => c.GiaSanPham).HasColumnType("int");
            //builder.Property(c => c.SlTon).HasColumnType("int");
            //builder.Property(c => c.TrangThai).HasColumnType("int");
            //builder.Property(c => c.GioiTinh).HasColumnType("int");
            //builder.Property(c => c.ThoiGianBaoHanh).HasColumnType("nvarchar(100)");
            //builder.Property(c => c.MieuTa).HasColumnType("nvarchar(1000)");
            //builder.Property(c => c.HinhAnh).HasColumnType("nvarchar(100)");
            // Khóa ngoại tính tiếp
            builder.HasOne(p => p.ThuongHieus).WithMany(p => p.sanPhams).HasForeignKey(p => p.IdThuongHieu).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.SuatXus).WithMany(p => p.sanPhams).HasForeignKey(p => p.IdXuatSu).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.LoaiMays).WithMany(p => p.sanPhams).HasForeignKey(p => p.IdLoaiMay).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Nsxes).WithMany(p => p.sanPhams).HasForeignKey(p => p.IdNsx).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
