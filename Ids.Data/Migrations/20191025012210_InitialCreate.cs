using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ids.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    RuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RxExp = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "SensorEventLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<string>(nullable: true),
                    SourceAddress = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    DestinationAddress = table.Column<string>(nullable: true),
                    DestinatiionPort = table.Column<int>(nullable: false),
                    TimeVal = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorEventLogs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "SensorHeartBeatLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorId = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Filter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorHeartBeatLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    AlertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatasourceId = table.Column<Guid>(nullable: false),
                    SourceIp = table.Column<string>(nullable: true),
                    SourcePort = table.Column<int>(nullable: false),
                    DestinationIp = table.Column<string>(nullable: true),
                    DestinationPort = table.Column<int>(nullable: false),
                    Payload = table.Column<string>(nullable: true),
                    Captured = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    RuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_Alerts_Rule_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rule",
                        principalColumn: "RuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_RuleId",
                table: "Alerts",
                column: "RuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "SensorEventLogs");

            migrationBuilder.DropTable(
                name: "SensorHeartBeatLogs");

            migrationBuilder.DropTable(
                name: "Rule");
        }
    }
}
