using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmSample.DataAccessLayer.Migrations
{
    public partial class create_confirmedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmedControlCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmedControlCode",
                table: "AspNetUsers");
        }
    }
}
