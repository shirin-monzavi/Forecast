using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forecast.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HourlyUnitsDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature2m = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relativehumidity2m = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Windspeed10m = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUnitsDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    GenerationtimeMs = table.Column<double>(type: "float", nullable: false),
                    UtcOffinitSeconds = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimezoneAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevation = table.Column<double>(type: "float", nullable: false),
                    HourlyUnitsId = table.Column<int>(type: "int", nullable: true),
                    Hourly = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastDto_HourlyUnitsDto_HourlyUnitsId",
                        column: x => x.HourlyUnitsId,
                        principalTable: "HourlyUnitsDto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDto_HourlyUnitsId",
                table: "ForecastDto",
                column: "HourlyUnitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastDto");

            migrationBuilder.DropTable(
                name: "HourlyUnitsDto");
        }
    }
}
