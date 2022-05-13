using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Observatory.Data.Migrations
{
    public partial class InitialPersistedGrantDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeX = table.Column<double>(type: "float", nullable: false),
                    SizeY = table.Column<double>(type: "float", nullable: false),
                    SizeZ = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeX = table.Column<double>(type: "float", nullable: false),
                    SizeY = table.Column<double>(type: "float", nullable: false),
                    SizeZ = table.Column<double>(type: "float", nullable: false),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    InfoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model3d = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_planets_area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "area",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_planets_AreaId",
                table: "planets",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "planets");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
