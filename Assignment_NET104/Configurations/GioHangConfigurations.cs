using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET104.Configurations
{
    public class GioHangConfigurations : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang"); // Đặt tên cho bảng
            builder.HasKey(c => new { c.IdNguoiDung, c.IdSp });// Set khóa chính
                                       // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
                                       //builder.Property(c => c.Id).HasColumnName("id").IsRequired();
                                       //builder.Property(c => c.SoLuong).HasColumnType("int");

            //builder.Property(c => c.GiaTien).HasColumnType("int");
            // Khóa ngoại tính tiếp
             builder.HasOne<SanPham>(c => c.SanPham)
            .WithMany()
            .HasForeignKey(c => c.IdSp)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<NguoiDung>(c => c.NguoiDung)
            .WithMany()
            .HasForeignKey(c => c.IdNguoiDung)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
