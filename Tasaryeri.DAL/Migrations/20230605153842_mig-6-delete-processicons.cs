using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasaryeri.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig6deleteprocessicons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessIcon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessIcon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoIcon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    MoneyIcon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    PcIcon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    UserIcon = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessIcon", x => x.Id);
                });
        }
    }
}
