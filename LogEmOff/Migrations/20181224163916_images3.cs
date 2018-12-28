using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogEmOff.Migrations
{
    public partial class images3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "GreenImage",
                table: "Logins",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RedImage",
                table: "Logins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreenImage",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "RedImage",
                table: "Logins");
        }
    }
}
