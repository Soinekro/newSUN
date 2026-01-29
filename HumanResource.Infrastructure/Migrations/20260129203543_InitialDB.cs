using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrEmployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SecStatus = table.Column<bool>(type: "bit", nullable: false),
                    SecUserId = table.Column<int>(type: "int", nullable: false),
                    SecCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecUserUpdate = table.Column<int>(type: "int", nullable: true),
                    SecUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmployees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "HrContracts",
                columns: table => new
                {
                    CtrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    SecStatus = table.Column<bool>(type: "bit", nullable: false),
                    SecUserId = table.Column<int>(type: "int", nullable: false),
                    SecCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecUserUpdate = table.Column<int>(type: "int", nullable: true),
                    SecUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrContracts", x => x.CtrId);
                    table.ForeignKey(
                        name: "FK_HrContracts_HrEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "HrEmployees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrContracts_EmployeeId",
                table: "HrContracts",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrContracts");

            migrationBuilder.DropTable(
                name: "HrEmployees");
        }
    }
}
