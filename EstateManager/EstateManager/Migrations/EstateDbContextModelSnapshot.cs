﻿// <auto-generated />
using System;
using EstateManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstateManager.Migrations
{
    [DbContext(typeof(EstateDbContext))]
    partial class EstateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("EstateManager.Model.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CloseDate");

                    b.Property<string>("Description");

                    b.Property<int>("EstateId");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PubDate");

                    b.Property<DateTime?>("SignDate");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("EstateId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("EstateManager.Model.Estate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("BuildDate");

                    b.Property<string>("City");

                    b.Property<int>("EnergyEfficiency");

                    b.Property<int>("FloorCount");

                    b.Property<int>("FloorNumber");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<int?>("MainPhotoId");

                    b.Property<int>("OwnerId");

                    b.Property<int>("RoomsCount");

                    b.Property<float>("Surface");

                    b.Property<int>("Type");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("MainPhotoId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Estate");
                });

            modelBuilder.Entity("EstateManager.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CellPhone");

                    b.Property<string>("City");

                    b.Property<string>("FirstName");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("Quality");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("EstateManager.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("EstateId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("EstateId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("EstateManager.Model.Contract", b =>
                {
                    b.HasOne("EstateManager.Model.Estate", "Estate")
                        .WithMany("Contracts")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManager.Model.Estate", b =>
                {
                    b.HasOne("EstateManager.Model.Photo", "MainPhoto")
                        .WithMany()
                        .HasForeignKey("MainPhotoId");

                    b.HasOne("EstateManager.Model.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EstateManager.Model.Photo", b =>
                {
                    b.HasOne("EstateManager.Model.Estate", "Estate")
                        .WithMany("Photos")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}