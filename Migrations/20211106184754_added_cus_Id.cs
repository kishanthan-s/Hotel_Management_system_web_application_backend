using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class added_cus_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_ID",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_ID",
                table: "Images");
        }
    }
}
