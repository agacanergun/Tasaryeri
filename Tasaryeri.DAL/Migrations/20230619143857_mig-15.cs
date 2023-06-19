using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasaryeri.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Member_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Saler_RecipientId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_RecipientId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_SenderId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(110)",
                maxLength: 110,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalerId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_MemberId",
                table: "Message",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SalerId",
                table: "Message",
                column: "SalerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Member_MemberId",
                table: "Message",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Saler_SalerId",
                table: "Message",
                column: "SalerId",
                principalTable: "Saler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Member_MemberId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Saler_SalerId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_MemberId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_SalerId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SalerId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(110)",
                oldMaxLength: 110,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_RecipientId",
                table: "Message",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Member_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Product_ProductId",
                table: "Message",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Saler_RecipientId",
                table: "Message",
                column: "RecipientId",
                principalTable: "Saler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
