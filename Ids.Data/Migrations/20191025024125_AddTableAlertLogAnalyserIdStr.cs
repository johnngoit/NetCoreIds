using Microsoft.EntityFrameworkCore.Migrations;

namespace Ids.Data.Migrations
{
    public partial class AddTableAlertLogAnalyserIdStr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnalyserId",
                table: "AlertLogs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnalyserId",
                table: "AlertLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
