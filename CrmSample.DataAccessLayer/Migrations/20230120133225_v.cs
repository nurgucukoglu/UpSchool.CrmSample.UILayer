using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmSample.DataAccessLayer.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "EmployeeTasks");
        }
    }
}
