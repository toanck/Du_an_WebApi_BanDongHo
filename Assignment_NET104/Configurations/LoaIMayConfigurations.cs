using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class LoaIMayConfigurations : IEntityTypeConfiguration<LoaiMay>
    {
        public void Configure(EntityTypeBuilder<LoaiMay> builder)
        {
            builder.ToTable("LoaiMay"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.TenLoaiMay).HasColumnType("nvarchar(1000)")
                .IsRequired();
            builder.Property(c => c.MoTa).HasColumnType("nvarchar(1000)");
            // Khóa ngoại tính tiếp
         
        }
    }
}
