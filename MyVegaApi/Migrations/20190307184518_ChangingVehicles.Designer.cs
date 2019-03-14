﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyVegaApi.Models;
using MyVegaApi.Persistence;
namespace MyVegaApi.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20190307184518_ChangingVehicles")]
    partial class ChangingVehicles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyVegaApi.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("MyVegaApi.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("MyVegaApi.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("MyVegaApi.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactAddress");

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("ContactName")
                        .IsRequired();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("ModelID");

                    b.HasKey("VehicleID");

                    b.HasIndex("ModelID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("MyVegaApi.Models.VehicleFeatures", b =>
                {
                    b.Property<int>("VehicleID");

                    b.Property<int>("FeatureID");

                    b.HasKey("VehicleID", "FeatureID");

                    b.HasIndex("FeatureID");

                    b.ToTable("VehicleFeature");
                });

            modelBuilder.Entity("MyVegaApi.Models.Model", b =>
                {
                    b.HasOne("MyVegaApi.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyVegaApi.Models.Vehicle", b =>
                {
                    b.HasOne("MyVegaApi.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyVegaApi.Models.VehicleFeatures", b =>
                {
                    b.HasOne("MyVegaApi.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyVegaApi.Models.Vehicle", "Vehicle")
                        .WithMany("Features")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}