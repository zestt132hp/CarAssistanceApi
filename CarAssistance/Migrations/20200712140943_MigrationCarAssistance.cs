using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarAssistance.Migrations
{
    public partial class MigrationCarAssistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyType",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BodyTypeName = table.Column<string>(nullable: true),
                    CountDoors = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandTires",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FuelType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBox",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GearBoxType = table.Column<string>(nullable: false),
                    CountGears = table.Column<int>(nullable: false),
                    NumberGearBox = table.Column<string>(nullable: true),
                    VehicleDriveId = table.Column<int>(nullable: false),
                    GearNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacter",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(nullable: true),
                    YearStart = table.Column<DateTime>(nullable: false),
                    YearEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelTires",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiresSeason",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Password = table.Column<string>(nullable: false),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeVehicleDrive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDrive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    UserNotesId = table.Column<int>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garage_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FuelId = table.Column<int>(nullable: false),
                    CountHPower = table.Column<int>(nullable: false),
                    CountKwt = table.Column<int>(nullable: false),
                    CapacityEngine = table.Column<double>(nullable: false),
                    EngineNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engine_FuelType_FuelId",
                        column: x => x.FuelId,
                        principalSchema: "public",
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilInfo",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OilName = table.Column<string>(nullable: true),
                    OilModel = table.Column<string>(nullable: true),
                    OilViscositySae = table.Column<string>(nullable: true),
                    OilTempeatureSae = table.Column<string>(nullable: true),
                    FuelId = table.Column<int>(nullable: false),
                    OilType = table.Column<string>(nullable: true),
                    OilVolume = table.Column<double>(nullable: false),
                    SpecificationOem = table.Column<string>(nullable: true),
                    SpecificationAcea = table.Column<string>(nullable: true),
                    SpecificationApi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilInfo_FuelType_FuelId",
                        column: x => x.FuelId,
                        principalSchema: "public",
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tires",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TiresSeasonId = table.Column<int>(nullable: false),
                    YearStartSales = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Radius = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tires", x => x.Id);
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
                        name: "FK_Tires_TiresSeason_TiresSeasonId",
                        column: x => x.TiresSeasonId,
                        principalSchema: "public",
                        principalTable: "TiresSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoteId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotes_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotes_Garage_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "public",
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarCharacteristics",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OilInfoId = table.Column<int>(nullable: false),
                    MileageRegister = table.Column<int>(nullable: false),
                    MileageNow = table.Column<int>(nullable: false),
                    Year = table.Column<DateTime>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCharacteristics_OilInfo_OilInfoId",
                        column: x => x.OilInfoId,
                        principalSchema: "public",
                        principalTable: "OilInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nodes = table.Column<string>(nullable: true),
                    UserNotesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_UserNotes_UserNotesId",
                        column: x => x.UserNotesId,
                        principalSchema: "public",
                        principalTable: "UserNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ManufactersId = table.Column<int>(nullable: false),
                    ModelsId = table.Column<int>(nullable: false),
                    CarNameId = table.Column<int>(nullable: false),
                    EngineId = table.Column<int>(nullable: false),
                    GearBoxesId = table.Column<int>(nullable: false),
                    CarCharcsId = table.Column<int>(nullable: false),
                    BodyTypeId = table.Column<int>(nullable: false),
                    TiresId = table.Column<int>(nullable: false),
                    GarageId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: true),
                    CharacteristicsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalSchema: "public",
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_CarCharacteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalSchema: "public",
                        principalTable: "CarCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Engine_EngineId",
                        column: x => x.EngineId,
                        principalSchema: "public",
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Garage_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "public",
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_GearBox_GearBoxesId",
                        column: x => x.GearBoxesId,
                        principalSchema: "public",
                        principalTable: "GearBox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Manufacter_ManufactersId",
                        column: x => x.ManufactersId,
                        principalSchema: "public",
                        principalTable: "Manufacter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Models_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "public",
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Tires_TiresId",
                        column: x => x.TiresId,
                        principalSchema: "public",
                        principalTable: "Tires",
                        principalColumn: "Id",
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
                name: "IX_Car_GearBoxesId",
                schema: "public",
                table: "Car",
                column: "GearBoxesId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ManufactersId",
                schema: "public",
                table: "Car",
                column: "ManufactersId");

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
                name: "IX_CarCharacteristics_OilInfoId",
                schema: "public",
                table: "CarCharacteristics",
                column: "OilInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_FuelId",
                schema: "public",
                table: "Engine",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_AccountId",
                schema: "public",
                table: "Garage",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserNotesId",
                schema: "public",
                table: "Notes",
                column: "UserNotesId");

            migrationBuilder.CreateIndex(
                name: "IX_OilInfo_FuelId",
                schema: "public",
                table: "OilInfo",
                column: "FuelId");

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
                name: "IX_Tires_TiresSeasonId",
                schema: "public",
                table: "Tires",
                column: "TiresSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_AccountId",
                schema: "public",
                table: "UserNotes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_GarageId",
                schema: "public",
                table: "UserNotes",
                column: "GarageId");

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
                name: "Notes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Users",
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
                name: "UserNotes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OilInfo",
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

            migrationBuilder.DropTable(
                name: "Garage",
                schema: "public");

            migrationBuilder.DropTable(
                name: "FuelType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "public");
        }
    }
}
