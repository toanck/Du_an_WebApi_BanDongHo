using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class ThuongHieuConfigurations : IEntityTypeConfiguration<ThuongHieu>
    {
        public void Configure(EntityTypeBuilder<ThuongHieu> builder)
        {
            builder.ToTable("ThuongHieu"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.TenThuongHieu).HasColumnType("nvarchar(100)")
                .IsRequired();
            builder.Property(c => c.MoTa).HasColumnType("nvarchar(100)")
             .IsRequired();

        }
    }
}
