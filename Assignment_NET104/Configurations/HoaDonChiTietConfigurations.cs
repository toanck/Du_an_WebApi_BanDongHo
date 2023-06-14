using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class HoaDonChiTietConfigurations : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.SLMua).HasColumnType("int");
            builder.Property(c => c.GiaTien).HasColumnType("int");
            builder.Property(c => c.NgayDat).HasColumnType("Datetime");
            builder.Property(c => c.NgayGiao).HasColumnType("Datetime");
            // Khóa ngoại 
            //builder.HasOne(p => p.HoaDon).WithMany().HasForeignKey(p => p.IdHoaDon);
            //builder.HasOne(p => p.SanPham).WithMany().HasForeignKey(p => p.IdSanPham);
            builder.HasOne(p => p.HoaDon).WithMany(q => q.hoaDonChiTiets).
               HasForeignKey(p => p.IdHoaDon);
            builder.HasOne(p => p.SanPham).WithMany(q => q.hoaDonChiTiets).
                HasForeignKey(p => p.IdSanPham); 
        }
    }
}
