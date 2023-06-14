using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_NET104.Migrations
{
    public partial class kaka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiMay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiMay = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMay", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Nsx",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNxs = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nsx", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SuatXu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiXuatSu = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuatXu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MieuTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdThuongHieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaSanPham = table.Column<long>(type: "bigint", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SlTon = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    IdXuatSu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLoaiMay = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNsx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThoiGianBaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MieuTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiMay_IdLoaiMay",
                        column: x => x.IdLoaiMay,
                        principalTable: "LoaiMay",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_Nsx_IdNsx",
                        column: x => x.IdNsx,
                        principalTable: "Nsx",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_SuatXu_IdXuatSu",
                        column: x => x.IdXuatSu,
                        principalTable: "SuatXu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_ThuongHieu_IdThuongHieu",
                        column: x => x.IdThuongHieu,
                        principalTable: "ThuongHieu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    IdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => new { x.IdNguoiDung, x.IdSp });
                    table.ForeignKey(
                        name: "FK_GioHang_SanPham_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Idvaitro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguoiDung = table.Column<string>(type: "varchar(256)", nullable: false),
                    TenDangNhap = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GioHangIdNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GioHangIdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_GioHang_GioHangIdNguoiDung_GioHangIdSp",
                        columns: x => new { x.GioHangIdNguoiDung, x.GioHangIdSp },
                        principalTable: "GioHang",
                        principalColumns: new[] { "IdNguoiDung", "IdSp" });
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_VaiTroId",
                        column: x => x.Idvaitro,
                        principalTable: "VaiTro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_UserID",
                        column: x => x.UserID,
                        principalTable: "NguoiDung",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLMua = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<int>(type: "int", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "Datetime", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.id);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_SanPham_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IdSp",
                table: "GioHang",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_UserID",
                table: "HoaDon",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdHoaDon",
                table: "HoaDonChiTiet",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdSanPham",
                table: "HoaDonChiTiet",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_GioHangIdNguoiDung_GioHangIdSp",
                table: "NguoiDung",
                columns: new[] { "GioHangIdNguoiDung", "GioHangIdSp" });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_VaiTroId",
                table: "NguoiDung",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdLoaiMay",
                table: "SanPham",
                column: "IdLoaiMay");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdNsx",
                table: "SanPham",
                column: "IdNsx");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdThuongHieu",
                table: "SanPham",
                column: "IdThuongHieu");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdXuatSu",
                table: "SanPham",
                column: "IdXuatSu");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHang_NguoiDung_IdNguoiDung",
                table: "GioHang",
                column: "IdNguoiDung",
                principalTable: "NguoiDung",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHang_NguoiDung_IdNguoiDung",
                table: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiMay");

            migrationBuilder.DropTable(
                name: "Nsx");

            migrationBuilder.DropTable(
                name: "SuatXu");

            migrationBuilder.DropTable(
                name: "ThuongHieu");
        }
    }
}
