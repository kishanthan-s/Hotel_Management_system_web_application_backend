using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Management.Migrations
{
    public partial class imaga1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Images",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Images",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
