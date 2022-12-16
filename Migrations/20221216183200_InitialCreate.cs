using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace WebCrawler.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeoAvailability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetIndustries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryCertifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
