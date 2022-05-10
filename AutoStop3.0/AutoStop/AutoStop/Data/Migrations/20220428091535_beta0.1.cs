using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoStop.Data.Migrations
{
    public partial class beta01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cars",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "NumberCar",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberCar",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cars",
                newName: "Number");
        }
    }
}
