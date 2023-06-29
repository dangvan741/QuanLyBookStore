using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBookStore.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_HopDong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    DateStart = table.Column<string>(type: "TEXT", nullable: false),
                    DateEnd = table.Column<string>(type: "TEXT", nullable: false),
                    Luong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_TenNV",
                        column: x => x.TenNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_TenNV",
                table: "HopDong",
                column: "TenNV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDong");
        }
    }
}
