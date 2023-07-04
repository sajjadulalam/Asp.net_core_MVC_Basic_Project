using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GtrTrainingHr.web.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HRent = table.Column<double>(type: "float", nullable: false),
                    Medical = table.Column<double>(type: "float", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departments_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "designations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DesigName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_designations_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ShiftName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShiftIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftLate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shifts_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gross = table.Column<double>(type: "float", nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HRent = table.Column<double>(type: "float", nullable: false),
                    Medical = table.Column<double>(type: "float", nullable: false),
                    Others = table.Column<double>(type: "float", nullable: false),
                    dtJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ShiftId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    DesigId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_employees_departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_employees_designations_DesigId",
                        column: x => x.DesigId,
                        principalTable: "designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_employees_shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attendances_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attendances_employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salarys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dtYear = table.Column<int>(type: "int", nullable: false),
                    dtMonth = table.Column<int>(type: "int", nullable: false),
                    Gross = table.Column<double>(type: "float", nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HRent = table.Column<double>(type: "float", nullable: false),
                    Medical = table.Column<double>(type: "float", nullable: false),
                    AbsentAmount = table.Column<double>(type: "float", nullable: false),
                    PayableAmount = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salarys_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_salarys_employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "attendanceSummaries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dtYear = table.Column<int>(type: "int", nullable: false),
                    dtMonth = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Present = table.Column<int>(type: "int", nullable: false),
                    Absent = table.Column<int>(type: "int", nullable: false),
                    Late = table.Column<int>(type: "int", nullable: false),
                    Weekend = table.Column<int>(type: "int", nullable: false),
                    SalaryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendanceSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attendanceSummaries_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attendanceSummaries_employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attendanceSummaries_salarys_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "salarys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendances_CompanyId",
                table: "attendances",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_attendances_EmpId",
                table: "attendances",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_attendanceSummaries_CompanyId",
                table: "attendanceSummaries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_attendanceSummaries_EmpId",
                table: "attendanceSummaries",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_attendanceSummaries_SalaryId",
                table: "attendanceSummaries",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_CompanyId",
                table: "departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_designations_CompanyId",
                table: "designations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_CompanyId",
                table: "employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DeptId",
                table: "employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DesigId",
                table: "employees",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_ShiftId",
                table: "employees",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_salarys_CompanyId",
                table: "salarys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_salarys_EmpId",
                table: "salarys",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CompanyId",
                table: "shifts",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendances");

            migrationBuilder.DropTable(
                name: "attendanceSummaries");

            migrationBuilder.DropTable(
                name: "salarys");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "designations");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
