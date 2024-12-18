using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaksiPro.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifflar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifflar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyurtmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MijozIsm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonRaqam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoshlanishManzil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TugashManzil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyurtmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyurtmalar_Tarifflar_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tarifflar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyurtmalar_TariffId",
                table: "Buyurtmalar",
                column: "TariffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyurtmalar");

            migrationBuilder.DropTable(
                name: "Contactlar");

            migrationBuilder.DropTable(
                name: "Tarifflar");
        }
    }
}
