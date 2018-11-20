using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogEmOff.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    AdminLogin = table.Column<string>(nullable: true),
                    AdminPassword = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(maxLength: 50, nullable: false),
                    ComputerIP = table.Column<string>(nullable: false),
                    ComputerMAC = table.Column<string>(nullable: true),
                    ComputerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ComputerID = table.Column<int>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 24, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    LoginID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Logins_Computers_ComputerID",
                        column: x => x.ComputerID,
                        principalTable: "Computers",
                        principalColumn: "ComputerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_ComputerID",
                table: "Logins",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserID",
                table: "Logins",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
