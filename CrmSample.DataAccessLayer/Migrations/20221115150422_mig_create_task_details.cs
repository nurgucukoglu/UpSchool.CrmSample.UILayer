using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmSample.DataAccessLayer.Migrations
{
    public partial class mig_create_task_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTaskDetails",
                columns: table => new
                {
                    EmployeeTaskDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskDetails", x => x.EmployeeTaskDetailId);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskDetails_EmployeeTasks_EmployeeTaskId",
                        column: x => x.EmployeeTaskId,
                        principalTable: "EmployeeTasks",
                        principalColumn: "EmployeeTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskDetails_EmployeeTaskId",
                table: "EmployeeTaskDetails",
                column: "EmployeeTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTaskDetails");
        }
    }
}
