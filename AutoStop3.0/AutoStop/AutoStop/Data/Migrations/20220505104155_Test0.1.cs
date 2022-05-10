using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoStop.Data.Migrations
{
    public partial class Test01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BusyPlaces",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "BusyPlaces",
                newName: "Id");
        }
    }
}
