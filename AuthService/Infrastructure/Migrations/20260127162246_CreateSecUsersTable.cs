using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateSecUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SecStatus = table.Column<bool>(type: "bit", nullable: false),
                    SecUserId = table.Column<int>(type: "int", nullable: false),
                    SecCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecUserUpdate = table.Column<int>(type: "int", nullable: true),
                    SecUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecUsers_Username",
                table: "SecUsers",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecUsers");
        }
    }
}
