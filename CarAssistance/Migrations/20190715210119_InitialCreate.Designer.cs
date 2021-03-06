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
    [Migration("20190715210119_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CarAssistance.Models.BodyType", b =>
                {
                    b.Property<int>("BodyTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BodyTypeName");

                    b.Property<int>("CountDoors");

                    b.HasKey("BodyTypeId");

                    b.ToTable("BodyType");
                });

            modelBuilder.Entity("CarAssistance.Models.BrandTires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandName");

                    b.HasKey("Id");

                    b.ToTable("BrandTires");
                });

            modelBuilder.Entity("CarAssistance.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodyTypeId");

                    b.Property<int>("CharacteristicsId");

                    b.Property<int>("EngineId");

                    b.Property<int?>("GarageId");

                    b.Property<int>("GearBoxId");

                    b.Property<int>("ManufacterId");

                    b.Property<int>("ModelId");

                    b.Property<int>("TiresId");

                    b.HasKey("CarId");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("CharacteristicsId");

                    b.HasIndex("EngineId");

                    b.HasIndex("GarageId");

                    b.HasIndex("GearBoxId");

                    b.HasIndex("ManufacterId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TiresId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarAssistance.Models.CarCharacteristics", b =>
                {
                    b.Property<int>("CarCharacteristicsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MileageNow");

                    b.Property<int>("MileageRegister");

                    b.Property<int?>("OilId");

                    b.HasKey("CarCharacteristicsId");

                    b.HasIndex("OilId");

                    b.ToTable("CarCharacteristics");
                });

            modelBuilder.Entity("CarAssistance.Models.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CapacityEngine");

                    b.Property<int>("CountHp");

                    b.Property<int>("CountKw");

                    b.Property<string>("EngineNumber");

                    b.Property<int?>("FuelTypeId");

                    b.HasKey("EngineId");

                    b.HasIndex("FuelTypeId");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("CarAssistance.Models.FuelType", b =>
                {
                    b.Property<int>("FuelTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FuelTypeName");

                    b.HasKey("FuelTypeId");

                    b.ToTable("FuelType");
                });

            modelBuilder.Entity("CarAssistance.Models.Garage", b =>
                {
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateRegister")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Note");

                    b.Property<Guid>("UserId");

                    b.HasKey("GarageId");

                    b.HasIndex("UserId");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("CarAssistance.Models.GearBox", b =>
                {
                    b.Property<int>("GearBoxId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountGear");

                    b.Property<string>("GearBoxType")
                        .IsRequired();

                    b.Property<string>("GearNumber")
                        .IsRequired();

                    b.HasKey("GearBoxId");

                    b.ToTable("GearBox");
                });

            modelBuilder.Entity("CarAssistance.Models.Manufacter", b =>
                {
                    b.Property<int>("ManufacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.HasKey("ManufacterId");

                    b.ToTable("Manufacter");
                });

            modelBuilder.Entity("CarAssistance.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ModelName");

                    b.Property<DateTime>("YearEnd");

                    b.Property<DateTime>("YearStart");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarAssistance.Models.ModelTires", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ModelName");

                    b.HasKey("Id");

                    b.ToTable("ModelTires");
                });

            modelBuilder.Entity("CarAssistance.Models.Oil", b =>
                {
                    b.Property<int>("OilId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acea");

                    b.Property<string>("Api");

                    b.Property<string>("Manufacter");

                    b.Property<string>("Model");

                    b.Property<string>("Sae");

                    b.Property<string>("TypeOil");

                    b.HasKey("OilId");

                    b.ToTable("Oil");
                });

            modelBuilder.Entity("CarAssistance.Models.Tires", b =>
                {
                    b.Property<int>("TiresId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrandId");

                    b.Property<int>("Height");

                    b.Property<int?>("ModelId");

                    b.Property<double>("Radius");

                    b.Property<int?>("SeasonId");

                    b.Property<int>("Width");

                    b.Property<int>("YearStartSale");

                    b.HasKey("TiresId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Tires");
                });

            modelBuilder.Entity("CarAssistance.Models.TiresSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Season");

                    b.HasKey("Id");

                    b.ToTable("TiresSeason");
                });

            modelBuilder.Entity("CarAssistance.Models.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<string>("LogIn")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeVehicleDrive");

                    b.HasKey("Id");

                    b.ToTable("VehicleDrive");
                });

            modelBuilder.Entity("CarAssistance.Models.Car", b =>
                {
                    b.HasOne("CarAssistance.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.CarCharacteristics", "Characteristics")
                        .WithMany()
                        .HasForeignKey("CharacteristicsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.Garage")
                        .WithMany("Car")
                        .HasForeignKey("GarageId");

                    b.HasOne("CarAssistance.Models.GearBox", "GearBox")
                        .WithMany()
                        .HasForeignKey("GearBoxId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.Manufacter", "Manufacter")
                        .WithMany()
                        .HasForeignKey("ManufacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarAssistance.Models.Tires", "Tires")
                        .WithMany()
                        .HasForeignKey("TiresId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarAssistance.Models.CarCharacteristics", b =>
                {
                    b.HasOne("CarAssistance.Models.Oil", "Oil")
                        .WithMany()
                        .HasForeignKey("OilId");
                });

            modelBuilder.Entity("CarAssistance.Models.Engine", b =>
                {
                    b.HasOne("CarAssistance.Models.FuelType", "Fuel")
                        .WithMany()
                        .HasForeignKey("FuelTypeId");
                });

            modelBuilder.Entity("CarAssistance.Models.Garage", b =>
                {
                    b.HasOne("CarAssistance.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .HasForeignKey("SeasonId");
                });
#pragma warning restore 612, 618
        }
    }
}
