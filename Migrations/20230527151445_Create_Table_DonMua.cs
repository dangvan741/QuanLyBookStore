using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBookStore.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_DonMua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonMua",
                columns: table => new
                {
                    MaDM = table.Column<string>(type: "TEXT", nullable: false),
                    TenKhach = table.Column<string>(type: "TEXT", nullable: false),
                    TenSach = table.Column<string>(type: "TEXT", nullable: false),
                    DateBuy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonMua", x => x.MaDM);
                    table.ForeignKey(
                        name: "FK_DonMua_Sach_TenSach",
                        column: x => x.TenSach,
                        principalTable: "Sach",
                        principalColumn: "MaSach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonMua_TenSach",
                table: "DonMua",
                column: "TenSach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonMua");
        }
    }
}
