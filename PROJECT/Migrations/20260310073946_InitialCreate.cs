using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    alert_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appliance_id = table.Column<int>(type: "int", nullable: false),
                    alert_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_resolved = table.Column<bool>(type: "bit", nullable: false),
                    severity = table.Column<double>(type: "float", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.alert_id);
                });

            migrationBuilder.CreateTable(
                name: "ApplianceTypes",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avg_energy_rating = table.Column<double>(type: "float", nullable: false),
                    avg_water_rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceTypes", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyUsages",
                columns: table => new
                {
                    energy_usage_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appliance_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cost_estimated = table.Column<double>(type: "float", nullable: false),
                    peak_usage = table.Column<double>(type: "float", nullable: false),
                    kwh_consumed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUsages", x => x.energy_usage_id);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Sensor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appliance_id = table.Column<int>(type: "int", nullable: false),
                    timestramp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reading_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Sensor_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "WaterUsages",
                columns: table => new
                {
                    water_usage_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appliance_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cycle_count = table.Column<int>(type: "int", nullable: false),
                    cost_estimated = table.Column<double>(type: "float", nullable: false),
                    liters_consumed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterUsages", x => x.water_usage_id);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    home_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.home_id);
                    table.ForeignKey(
                        name: "FK_Homes_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    alert_id = table.Column<int>(type: "int", nullable: false),
                    channel = table.Column<int>(type: "int", nullable: false),
                    sent_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_Notifications_Alerts_alert_id",
                        column: x => x.alert_id,
                        principalTable: "Alerts",
                        principalColumn: "alert_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appliances",
                columns: table => new
                {
                    appliance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    home_id = table.Column<int>(type: "int", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    device_identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    installed_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliances", x => x.appliance_id);
                    table.ForeignKey(
                        name: "FK_Appliances_ApplianceTypes_type_id",
                        column: x => x.type_id,
                        principalTable: "ApplianceTypes",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appliances_Homes_home_id",
                        column: x => x.home_id,
                        principalTable: "Homes",
                        principalColumn: "home_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SustainabilityScores",
                columns: table => new
                {
                    sustainablity_score_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    home_id = table.Column<int>(type: "int", nullable: false),
                    period_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    energy_score = table.Column<double>(type: "float", nullable: false),
                    water_score = table.Column<double>(type: "float", nullable: false),
                    period_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    overall_score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SustainabilityScores", x => x.sustainablity_score_id);
                    table.ForeignKey(
                        name: "FK_SustainabilityScores_Homes_home_id",
                        column: x => x.home_id,
                        principalTable: "Homes",
                        principalColumn: "home_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_home_id",
                table: "Appliances",
                column: "home_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_type_id",
                table: "Appliances",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_user_id",
                table: "Homes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_alert_id",
                table: "Notifications",
                column: "alert_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_SustainabilityScores_home_id",
                table: "SustainabilityScores",
                column: "home_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appliances");

            migrationBuilder.DropTable(
                name: "EnergyUsages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "SustainabilityScores");

            migrationBuilder.DropTable(
                name: "WaterUsages");

            migrationBuilder.DropTable(
                name: "ApplianceTypes");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
