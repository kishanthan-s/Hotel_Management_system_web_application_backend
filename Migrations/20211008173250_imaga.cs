using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class imaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "nvarchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "Id");
        }
    }
}
