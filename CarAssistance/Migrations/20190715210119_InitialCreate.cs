using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarAssistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "BodyType",
                schema: "public",
                columns: table => new
                {
                    BodyTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BodyTypeName = table.Column<string>(nullable: true),
                    CountDoors = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.BodyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BrandTires",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BrandName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                schema: "public",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FuelTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.FuelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GearBox",
                schema: "public",
                columns: table => new
                {
                    GearBoxId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GearBoxType = table.Column<string>(nullable: false),
                    CountGear = table.Column<int>(nullable: false),
                    GearNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBox", x => x.GearBoxId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacter",
                schema: "public",
                columns: table => new
                {
                    ManufacterId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacter", x => x.ManufacterId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                schema: "public",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ModelName = table.Column<string>(nullable: true),
                    YearStart = table.Column<DateTime>(nullable: false),
                    YearEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "ModelTires",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oil",
                schema: "public",
                columns: table => new
                {
                    OilId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Manufacter = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    TypeOil = table.Column<string>(nullable: true),
                    Acea = table.Column<string>(nullable: true),
                    Sae = table.Column<string>(nullable: true),
                    Api = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oil", x => x.OilId);
                });

            migrationBuilder.CreateTable(
                name: "TiresSeason",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Season = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiresSeason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "public",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    LogIn = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDrive",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TypeVehicleDrive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDrive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                schema: "public",
                columns: table => new
                {
                    EngineId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FuelTypeId = table.Column<int>(nullable: true),
                    CountHp = table.Column<int>(nullable: false),
                    CountKw = table.Column<int>(nullable: false),
                    CapacityEngine = table.Column<double>(nullable: false),
                    EngineNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.EngineId);
                    table.ForeignKey(
                        name: "FK_Engine_FuelType_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalSchema: "public",
                        principalTable: "FuelType",
                        principalColumn: "FuelTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarCharacteristics",
                schema: "public",
                columns: table => new
                {
                    CarCharacteristicsId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MileageRegister = table.Column<int>(nullable: false),
                    OilId = table.Column<int>(nullable: true),
                    MileageNow = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCharacteristics_1", x => x.CarCharacteristicsId);
                    table.ForeignKey(
                        name: "FK_CarCharacteristics_1_Oil_OilId",
                        column: x => x.OilId,
                        principalSchema: "public",
                        principalTable: "Oil",
                        principalColumn: "OilId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tires",
                schema: "public",
                columns: table => new
                {
                    TiresId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SeasonId = table.Column<int>(nullable: true),
                    YearStartSale = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Radius = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tires", x => x.TiresId);
                    table.ForeignKey(
                        name: "FK_Tires_BrandTires_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "public",
                        principalTable: "BrandTires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tires_ModelTires_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "public",
                        principalTable: "ModelTires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tires_TiresSeason_SeasonId",
                        column: x => x.SeasonId,
                        principalSchema: "public",
                        principalTable: "TiresSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                schema: "public",
                columns: table => new
                {
                    GarageId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GarageId);
                    table.ForeignKey(
                        name: "FK_Garage_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "public",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ManufacterId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    EngineId = table.Column<int>(nullable: false),
                    GearBoxId = table.Column<int>(nullable: false),
                    BodyTypeId = table.Column<int>(nullable: false),
                    TiresId = table.Column<int>(nullable: false),
                    CharacteristicsId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalSchema: "public",
                        principalTable: "BodyType",
                        principalColumn: "BodyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_CarCharacteristics_1_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalSchema: "public",
                        principalTable: "CarCharacteristics",
                        principalColumn: "CarCharacteristicsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Engine_EngineId",
                        column: x => x.EngineId,
                        principalSchema: "public",
                        principalTable: "Engine",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Garage_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "public",
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_GearBox_GearBoxId",
                        column: x => x.GearBoxId,
                        principalSchema: "public",
                        principalTable: "GearBox",
                        principalColumn: "GearBoxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Manufacter_ManufacterId",
                        column: x => x.ManufacterId,
                        principalSchema: "public",
                        principalTable: "Manufacter",
                        principalColumn: "ManufacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "public",
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Tires_TiresId",
                        column: x => x.TiresId,
                        principalSchema: "public",
                        principalTable: "Tires",
                        principalColumn: "TiresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyTypeId",
                schema: "public",
                table: "Car",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CharacteristicsId",
                schema: "public",
                table: "Car",
                column: "CharacteristicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                schema: "public",
                table: "Car",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_GarageId",
                schema: "public",
                table: "Car",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_GearBoxId",
                schema: "public",
                table: "Car",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ManufacterId",
                schema: "public",
                table: "Car",
                column: "ManufacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                schema: "public",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TiresId",
                schema: "public",
                table: "Car",
                column: "TiresId");

            migrationBuilder.CreateIndex(
                name: "IX_CarCharacteristics_1_OilId",
                schema: "public",
                table: "CarCharacteristics",
                column: "OilId");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_FuelTypeId",
                schema: "public",
                table: "Engine",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_UserId",
                schema: "public",
                table: "Garage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tires_BrandId",
                schema: "public",
                table: "Tires",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Tires_ModelId",
                schema: "public",
                table: "Tires",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tires_SeasonId",
                schema: "public",
                table: "Tires",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "public",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LogIn",
                schema: "public",
                table: "Users",
                column: "LogIn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                schema: "public",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car",
                schema: "public");

            migrationBuilder.DropTable(
                name: "VehicleDrive",
                schema: "public");

            migrationBuilder.DropTable(
                name: "BodyType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CarCharacteristics",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Engine",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Garage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "GearBox",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Manufacter",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Models",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tires",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Oil",
                schema: "public");

            migrationBuilder.DropTable(
                name: "FuelType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "BrandTires",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ModelTires",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TiresSeason",
                schema: "public");
        }
    }
}
