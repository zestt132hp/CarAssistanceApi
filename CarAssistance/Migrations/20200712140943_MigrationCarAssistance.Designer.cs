﻿// <auto-generated />
using System;
using CarAssistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarAssistance.Migrations
{
    [DbContext(typeof(NpgSqlDataContext))]
    [Migration("20200712140943_MigrationCarAssistance")]
    partial class MigrationCarAssistance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CarAssistance.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CarAssistance.Models.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BodyTypeName")
                        .HasColumnType("text");

                    b.Property<int>("CountDoors")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BodyType");
                });

            modelBuilder.Entity("CarAssistance.Models.BrandTires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BrandName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BrandTires");
                });

            modelBuilder.Entity("CarAssistance.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("CarCharcsId")
                        .HasColumnType("integer");

                    b.Property<int>("CarNameId")
                        .HasColumnType("integer");

                    b.Property<int?>("CharacteristicsId")
                        .HasColumnType("integer");

                    b.Property<int>("EngineId")
                        .HasColumnType("integer");

                    b.Property<int>("GarageId")
                        .HasColumnType("integer");

                    b.Property<int>("GearBoxesId")
                        .HasColumnType("integer");

                    b.Property<int>("ManufactersId")
                        .HasColumnType("integer");

                    b.Property<int?>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("ModelsId")
                        .HasColumnType("integer");

                    b.Property<int>("TiresId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("CharacteristicsId");

                    b.HasIndex("EngineId");

                    b.HasIndex("GarageId");

                    b.HasIndex("GearBoxesId");

                    b.HasIndex("ManufactersId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TiresId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarAssistance.Models.CarCharacteristics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int>("MileageNow")
                        .HasColumnType("integer");

                    b.Property<int>("MileageRegister")
                        .HasColumnType("integer");

                    b.Property<int>("OilInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Year")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("OilInfoId");

                    b.ToTable("CarCharacteristics");
                });

            modelBuilder.Entity("CarAssistance.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("CapacityEngine")
                        .HasColumnType("double precision");

                    b.Property<int>("CountHPower")
                        .HasColumnType("integer");

                    b.Property<int>("CountKwt")
                        .HasColumnType("integer");

                    b.Property<string>("EngineNumber")
                        .HasColumnType("text");

                    b.Property<int>("FuelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FuelId");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("CarAssistance.Models.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FuelType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FuelType");
                });

            modelBuilder.Entity("CarAssistance.Models.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateRegister")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserNotesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("CarAssistance.Models.GearBoxes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CountGears")
                        .HasColumnType("integer");

                    b.Property<string>("GearBoxType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GearNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberGearBox")
                        .HasColumnType("text");

                    b.Property<int>("VehicleDriveId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GearBox");
                });

            modelBuilder.Entity("CarAssistance.Models.Manufacters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Manufacter");
                });

            modelBuilder.Entity("CarAssistance.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ModelName")
                        .HasColumnType("text");

                    b.Property<DateTime>("YearEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("YearStart")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarAssistance.Models.ModelTires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ModelName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ModelTires");
                });

            modelBuilder.Entity("CarAssistance.Models.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nodes")
                        .HasColumnType("text");

                    b.Property<int?>("UserNotesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserNotesId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("CarAssistance.Models.OilInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FuelId")
                        .HasColumnType("integer");

                    b.Property<string>("OilModel")
                        .HasColumnType("text");

                    b.Property<string>("OilName")
                        .HasColumnType("text");

                    b.Property<string>("OilTempeatureSae")
                        .HasColumnType("text");

                    b.Property<string>("OilType")
                        .HasColumnType("text");

                    b.Property<string>("OilViscositySae")
                        .HasColumnType("text");

                    b.Property<double>("OilVolume")
                        .HasColumnType("double precision");

                    b.Property<string>("SpecificationAcea")
                        .HasColumnType("text");

                    b.Property<string>("SpecificationApi")
                        .HasColumnType("text");

                    b.Property<string>("SpecificationOem")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FuelId");

                    b.ToTable("OilInfo");
                });

            modelBuilder.Entity("CarAssistance.Models.Tires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int?>("ModelId")
                        .HasColumnType("integer");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<int>("TiresSeasonId")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.Property<int>("YearStartSales")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TiresSeasonId");

                    b.ToTable("Tires");
                });

            modelBuilder.Entity("CarAssistance.Models.TiresSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Season")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TiresSeason");
                });

            modelBuilder.Entity("CarAssistance.Models.UserNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int?>("GarageId")
                        .HasColumnType("integer");

                    b.Property<int>("NoteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("GarageId");

                    b.ToTable("UserNotes");
                });

            modelBuilder.Entity("CarAssistance.Models.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("LogIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("LogIn")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarAssistance.Models.VehicleDrive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TypeVehicleDrive")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VehicleDrive");
                });

            modelBuilder.Entity("CarAssistance.Models.Car", b =>
                {
                    b.HasOne("CarAssistance.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.CarCharacteristics", "Characteristics")
                        .WithMany()
                        .HasForeignKey("CharacteristicsId");

                    b.HasOne("CarAssistance.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.Garage", "Garage")
                        .WithMany("Cars")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.GearBoxes", "GearBox")
                        .WithMany()
                        .HasForeignKey("GearBoxesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.Manufacters", "Manufacter")
                        .WithMany()
                        .HasForeignKey("ManufactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.HasOne("CarAssistance.Models.Tires", "Tires")
                        .WithMany()
                        .HasForeignKey("TiresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.CarCharacteristics", b =>
                {
                    b.HasOne("CarAssistance.Models.OilInfo", "Oil")
                        .WithMany()
                        .HasForeignKey("OilInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.Engine", b =>
                {
                    b.HasOne("CarAssistance.Models.Fuel", "Fuel")
                        .WithMany()
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.Garage", b =>
                {
                    b.HasOne("CarAssistance.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.Notes", b =>
                {
                    b.HasOne("CarAssistance.Models.UserNotes", null)
                        .WithMany("Notes")
                        .HasForeignKey("UserNotesId");
                });

            modelBuilder.Entity("CarAssistance.Models.OilInfo", b =>
                {
                    b.HasOne("CarAssistance.Models.Fuel", "Fuel")
                        .WithMany()
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.Tires", b =>
                {
                    b.HasOne("CarAssistance.Models.BrandTires", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("CarAssistance.Models.ModelTires", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.HasOne("CarAssistance.Models.TiresSeason", "Season")
                        .WithMany()
                        .HasForeignKey("TiresSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarAssistance.Models.UserNotes", b =>
                {
                    b.HasOne("CarAssistance.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarAssistance.Models.Garage", null)
                        .WithMany("UserNotes")
                        .HasForeignKey("GarageId");
                });
#pragma warning restore 612, 618
        }
    }
}