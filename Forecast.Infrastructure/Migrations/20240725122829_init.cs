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
                name: "Forecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Generationtime_Ms = table.Column<double>(type: "float", nullable: false),
                    Utc_Off_initSeconds = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone_Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevation = table.Column<double>(type: "float", nullable: false),
                    Hourly = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature2m = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relativehumidity2m = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Windspeed10m = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForecastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyUnits_Forecast_ForecastId",
                        column: x => x.ForecastId,
                        principalTable: "Forecast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlyUnits_ForecastId",
                table: "HourlyUnits",
                column: "ForecastId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlyUnits");

            migrationBuilder.DropTable(
                name: "Forecast");
        }
    }
}
