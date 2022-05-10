using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoStop.Data.Migrations
{
    public partial class Beta02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FavoriteList_FavoriteListid",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "FavoriteList");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FavoriteListid",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FavoriteLisetId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FavoriteListid",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteLisetId",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteListid",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FavoriteList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteList", x => x.id);
                    table.ForeignKey(
                        name: "FK_FavoriteList_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FavoriteListid",
                table: "Cars",
                column: "FavoriteListid");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteList_AccountId",
                table: "FavoriteList",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FavoriteList_FavoriteListid",
                table: "Cars",
                column: "FavoriteListid",
                principalTable: "FavoriteList",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
