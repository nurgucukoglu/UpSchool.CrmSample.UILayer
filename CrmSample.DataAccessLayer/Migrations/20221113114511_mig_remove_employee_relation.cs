using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmSample.DataAccessLayer.Migrations
{
    public partial class mig_remove_employee_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeID",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_EmployeeID",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "EmployeeTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeID",
                table: "EmployeeTasks",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EmployeeID",
                table: "EmployeeTasks",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
