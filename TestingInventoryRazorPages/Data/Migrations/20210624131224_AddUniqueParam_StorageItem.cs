using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingInventoryRazorPages.Data.Migrations
{
    public partial class AddUniqueParam_StorageItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StorageItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageItem_Description",
                table: "StorageItem",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StorageItem_Description",
                table: "StorageItem");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StorageItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
