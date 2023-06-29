using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBookStore.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Sach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    MaSach = table.Column<string>(type: "TEXT", nullable: false),
                    TenSach = table.Column<string>(type: "TEXT", nullable: false),
                    TenNXB = table.Column<string>(type: "TEXT", nullable: false),
                    Gia = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.MaSach);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sach");
        }
    }
}
