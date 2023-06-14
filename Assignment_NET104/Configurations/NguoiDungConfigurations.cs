using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class NguoiDungConfigurations : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.ToTable("NguoiDung"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.TenNguoiDung).HasColumnType("varchar(256)")
                .IsRequired(); 
            builder.Property(c => c.TenDangNhap).IsUnicode(false).IsRequired();
            builder.Property(c => c.MatKhau).IsUnicode(false).IsRequired();
                
            builder.Property(c => c.Email).HasColumnType("varchar(256)");
            
            builder.Property(c => c.TrangThai).HasColumnType("nvarchar(50)");
            // Khóa ngoại tính tiếp
            //builder.HasOne(p => p.VaiTros).WithMany().HasForeignKey(p => p.IDVaiTro);
        }
    }
}
