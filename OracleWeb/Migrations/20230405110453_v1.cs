using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleWeb.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "K19");

            migrationBuilder.CreateTable(
                name: "Positon",
                schema: "K19",
                columns: table => new
                {
                    Positon_Id = table.Column<decimal>(type: "NUMBER", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "FLOAT", nullable: true),
                    isDelete = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positon", x => x.Positon_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "K19",
                columns: table => new
                {
                    Employee_Id = table.Column<decimal>(type: "NUMBER", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: false),
                    Birth = table.Column<DateTime>(type: "DATE", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<decimal>(type: "NUMBER", nullable: true),
                    isDelete = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Positon_Id = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "has",
                        column: x => x.Positon_Id,
                        principalSchema: "K19",
                        principalTable: "Positon",
                        principalColumn: "Positon_Id");
                });

            migrationBuilder.CreateTable(
                name: "PayRoll",
                schema: "K19",
                columns: table => new
                {
                    PayRoll_id = table.Column<decimal>(type: "NUMBER", nullable: false),
                    Total_Hour_In_a_month = table.Column<decimal>(type: "NUMBER", nullable: true),
                    Coefficients = table.Column<decimal>(type: "FLOAT", nullable: true),
                    Total_Salary = table.Column<decimal>(type: "NUMBER", nullable: true),
                    Date_paid = table.Column<DateTime>(type: "DATE", nullable: true),
                    isDelete = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Employee_Id = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayRoll", x => x.PayRoll_id);
                    table.ForeignKey(
                        name: "FK_Employee_Payroll",
                        column: x => x.Employee_Id,
                        principalSchema: "K19",
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateTable(
                name: "Timekeeping",
                schema: "K19",
                columns: table => new
                {
                    Timekeeping_id = table.Column<decimal>(type: "NUMBER", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "DATE", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "DATE", nullable: true),
                    TotalHours = table.Column<decimal>(type: "NUMBER", nullable: true),
                    isDelete = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Employee_Id = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timekeeping", x => x.Timekeeping_id);
                    table.ForeignKey(
                        name: "FK_Employee_TimeKeeping",
                        column: x => x.Employee_Id,
                        principalSchema: "K19",
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationship5",
                schema: "K19",
                table: "Employee",
                column: "Positon_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship6",
                schema: "K19",
                table: "PayRoll",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship7",
                schema: "K19",
                table: "Timekeeping",
                column: "Employee_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayRoll",
                schema: "K19");

            migrationBuilder.DropTable(
                name: "Timekeeping",
                schema: "K19");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "K19");

            migrationBuilder.DropTable(
                name: "Positon",
                schema: "K19");
        }
    }
}
