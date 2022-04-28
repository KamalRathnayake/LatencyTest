using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LatencyDemo.FnApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LatencyTestRun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeTakenMS = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatencyTestRun", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LatencyTestRun");
        }
    }
}
