using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LatencyDemo.FnApp.Migrations
{
    public partial class BodyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "LatencyTestRun",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request",
                table: "LatencyTestRun");
        }
    }
}
