using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAssistance.Migrations
{
    public partial class AddManufacterToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManufactersId",
                schema: "public",
                table: "Models",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufactersId",
                schema: "public",
                table: "Models",
                column: "ManufactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Manufacter_ManufactersId",
                schema: "public",
                table: "Models",
                column: "ManufactersId",
                principalSchema: "public",
                principalTable: "Manufacter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Manufacter_ManufactersId",
                schema: "public",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ManufactersId",
                schema: "public",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ManufactersId",
                schema: "public",
                table: "Models");
        }
    }
}
