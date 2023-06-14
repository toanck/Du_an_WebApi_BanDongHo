using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104.Configurations
{
    public class HoaDonConfigurations:IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon"); // Đặt tên cho bảng
            builder.HasKey(c => c.id); // Set khóa chính
            // Set thuộc tính cho mỗi cột, mỗi Property là 1 cột
            //builder.Property(c => c.id).HasColumnName("id").IsRequired();
            builder.Property(c => c.CreateDate).HasColumnType("DateTime")
                .IsRequired();
           builder.Property(c => c.IdNguoiDung).
                HasColumnName("UserID").IsRequired();
            builder.Property(c => c.TrangThai).HasColumnType("nvarchar(50)");
              
           
            // Khóa ngoại tính tiếp
            builder.HasOne(p => p.nguoiDung).WithMany().HasForeignKey(p => p.IdNguoiDung);
            
        }
    }
}
