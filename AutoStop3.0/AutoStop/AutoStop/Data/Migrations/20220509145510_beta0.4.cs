using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoStop.Data.Migrations
{
    public partial class beta04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "BlackList",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "BlackList");
        }
    }
}
