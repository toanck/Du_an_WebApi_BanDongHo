using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class VaiTroConfigurations : IEntityTypeConfiguration<VaiTro>
    {
        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.ToTable("VaiTro"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.TenVaiTro).HasColumnType("nvarchar(100)")
                .IsRequired();
            builder.Property(c => c.MieuTa).HasColumnType("nvarchar(1000)");
            builder.Property(c => c.TrangThai).HasColumnType("nvarchar(50)");
            // Khóa ngoại tính tiếp
            
        }
    }
}
