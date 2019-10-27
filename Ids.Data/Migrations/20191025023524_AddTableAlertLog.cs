using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ids.Data.Migrations
{
    public partial class AddTableAlertLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Rule_RuleId",
                table: "Alerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rule",
                table: "Rule");

            migrationBuilder.RenameTable(
                name: "Rule",
                newName: "Rules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rules",
                table: "Rules",
                column: "RuleId");

            migrationBuilder.CreateTable(
                name: "AlertLogs",
                columns: table => new
                {
                    AlertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalyserId = table.Column<int>(nullable: false),
                    IdmefMessage = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertLogs", x => x.AlertId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Rules_RuleId",
                table: "Alerts",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "RuleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Rules_RuleId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "AlertLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rules",
                table: "Rules");

            migrationBuilder.RenameTable(
                name: "Rules",
                newName: "Rule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rule",
                table: "Rule",
                column: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Rule_RuleId",
                table: "Alerts",
                column: "RuleId",
                principalTable: "Rule",
                principalColumn: "RuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
