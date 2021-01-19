using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAssistance.Migrations
{
    public partial class addNullableToModel_YearEnd_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "YearEnd",
                schema: "public",
                table: "Models",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "YearEnd",
                schema: "public",
                table: "Models",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
