﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project.Migrations
{
    [DbContext(typeof(BackendProjectContext))]
    [Migration("20210427183517_first migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cafe", b =>
                {
                    b.Property<Guid>("CafeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StadId")
                        .HasColumnType("int");

                    b.HasKey("CafeId");

                    b.HasIndex("StadId");

                    b.ToTable("Cafes");

                    b.HasData(
                        new
                        {
                            CafeId = new Guid("5caafc20-dd10-44f7-8373-3bfbfe923709"),
                            Adres = "GraafKarelDeGoedelaan 5, 8500 Kortrijk",
                            Naam = "Tbunkertje",
                            StadId = 1
                        },
                        new
                        {
                            CafeId = new Guid("1c61c178-c33f-470e-8d8a-d287b49ad8d9"),
                            Adres = "Doorniksesteenweg 2, 8500 Kortrijk",
                            Naam = "Tkanon",
                            StadId = 1
                        },
                        new
                        {
                            CafeId = new Guid("c91d83ca-4c49-4b37-82a6-bd71cc4566e7"),
                            Adres = "Eiermarkt 2, 8000 Brugge",
                            Naam = "De Pick",
                            StadId = 2
                        });
                });

            modelBuilder.Entity("Evenementen", b =>
                {
                    b.Property<Guid>("EvenementenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvenementenId");

                    b.ToTable("Evenementen");

                    b.HasData(
                        new
                        {
                            EvenementenId = new Guid("8aec76b1-8519-4138-a4d3-f1e6708ce71a"),
                            Beschrijving = "Commilitones! Zet jullie bierpotten klaar voor deze cantus! 20u30 Io Vivat",
                            Naam = "Zomercantus"
                        });
                });

            modelBuilder.Entity("EvenementenStudentenclub", b =>
                {
                    b.Property<Guid>("EvenementenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrganisatorsStudentenclubId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EvenementenId", "OrganisatorsStudentenclubId");

                    b.HasIndex("OrganisatorsStudentenclubId");

                    b.ToTable("EvenementenStudentenclub");
                });

            modelBuilder.Entity("Stad", b =>
                {
                    b.Property<int>("StadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadId");

                    b.ToTable("Steden");

                    b.HasData(
                        new
                        {
                            StadId = 1,
                            Naam = "Kortrijk",
                            Provincie = "West-Vlaanderen"
                        },
                        new
                        {
                            StadId = 2,
                            Naam = "Brugge",
                            Provincie = "West-Vlaanderen"
                        });
                });

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Studente");
                });

            modelBuilder.Entity("StudentStudentenclub", b =>
                {
                    b.Property<Guid>("ClubsStudentenclubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LedenStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClubsStudentenclubId", "LedenStudentId");

                    b.HasIndex("LedenStudentId");

                    b.ToTable("StudentStudentenclub");
                });

            modelBuilder.Entity("Studentenclub", b =>
                {
                    b.Property<Guid>("StudentenclubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CafeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CafeId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Oprichtingsjaar")
                        .HasColumnType("int");

                    b.Property<int>("StadId")
                        .HasColumnType("int");

                    b.HasKey("StudentenclubId");

                    b.HasIndex("CafeId1");

                    b.HasIndex("StadId");

                    b.ToTable("Studentenclubs");

                    b.HasData(
                        new
                        {
                            StudentenclubId = new Guid("f279460b-36a7-4cf4-a998-4b3ccb2dd3a1"),
                            Beschrijving = "De club van Howest en Ugent -> De beste club van Kortrijk!",
                            CafeId = 0,
                            Naam = "HsC Centaura",
                            Oprichtingsjaar = 1977,
                            StadId = 2
                        });
                });

            modelBuilder.Entity("Cafe", b =>
                {
                    b.HasOne("Stad", "Stad")
                        .WithMany("Cafes")
                        .HasForeignKey("StadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stad");
                });

            modelBuilder.Entity("EvenementenStudentenclub", b =>
                {
                    b.HasOne("Evenementen", null)
                        .WithMany()
                        .HasForeignKey("EvenementenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Studentenclub", null)
                        .WithMany()
                        .HasForeignKey("OrganisatorsStudentenclubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentStudentenclub", b =>
                {
                    b.HasOne("Studentenclub", null)
                        .WithMany()
                        .HasForeignKey("ClubsStudentenclubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", null)
                        .WithMany()
                        .HasForeignKey("LedenStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Studentenclub", b =>
                {
                    b.HasOne("Cafe", "Cafe")
                        .WithMany("Studentenclubs")
                        .HasForeignKey("CafeId1");

                    b.HasOne("Stad", "Stad")
                        .WithMany()
                        .HasForeignKey("StadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafe");

                    b.Navigation("Stad");
                });

            modelBuilder.Entity("Cafe", b =>
                {
                    b.Navigation("Studentenclubs");
                });

            modelBuilder.Entity("Stad", b =>
                {
                    b.Navigation("Cafes");
                });
#pragma warning restore 612, 618
        }
    }
}
