using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogEmOff.Migrations
{
    public partial class images2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ComputerMAC",
                table: "Computers",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GreenImage",
                table: "Computers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RedImage",
                table: "Computers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreenImage",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "RedImage",
                table: "Computers");

            migrationBuilder.AlterColumn<string>(
                name: "ComputerMAC",
                table: "Computers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
