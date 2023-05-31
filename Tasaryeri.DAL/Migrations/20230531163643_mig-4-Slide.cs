using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasaryeri.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4Slide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ShortDescription = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    LongDescription = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Link = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slide");
        }
    }
}
