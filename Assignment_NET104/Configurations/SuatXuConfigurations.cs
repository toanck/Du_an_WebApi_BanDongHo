using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class SuatXuConfigurations : IEntityTypeConfiguration<SuatXu>
    {
        public void Configure(EntityTypeBuilder<SuatXu> builder)
        {

            builder.ToTable("SuatXu"); // Đặt tên cho bảng
            builder.HasKey(c => c.Id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            builder.Property(c => c.Id).
                HasColumnName("id").IsRequired();
            builder.Property(c => c.NoiXuatSu).HasColumnType("nvarchar(100)")
                .IsRequired();
           
            // Khóa ngoại tính tiếp
        }
    }
}
