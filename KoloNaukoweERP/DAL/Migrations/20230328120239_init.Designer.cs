﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DbKoloNaukoweERP))]
    [Migration("20230328120239_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CzlonekZespol", b =>
                {
                    b.Property<int>("CzlonkowieIdCzlonka")
                        .HasColumnType("int");

                    b.Property<int>("ZespolyIdZespolu")
                        .HasColumnType("int");

                    b.HasKey("CzlonkowieIdCzlonka", "ZespolyIdZespolu");

                    b.HasIndex("ZespolyIdZespolu");

                    b.ToTable("CzlonekZespol");
                });

            modelBuilder.Entity("DAL.Czlonek", b =>
                {
                    b.Property<int>("IdCzlonka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCzlonka"));

                    b.Property<int>("IdPelnionejFunkcji")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KierunekStudiow")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NrTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uczelnia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wydzial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCzlonka");

                    b.HasIndex("IdPelnionejFunkcji");

                    b.ToTable("Czlonkowie");

                    b.HasData(
                        new
                        {
                            IdCzlonka = 1,
                            IdPelnionejFunkcji = 1,
                            Imie = "Daniel",
                            KierunekStudiow = "Informatyka Przemysłowa",
                            Mail = "daniel.malik@student.pl",
                            Nazwisko = "Malik",
                            NrTelefonu = "696-789-521",
                            Uczelnia = "Politechnika Śląska",
                            Wydzial = "Inżynierii Materiałowej"
                        },
                        new
                        {
                            IdCzlonka = 2,
                            IdPelnionejFunkcji = 2,
                            Imie = "Milosz",
                            KierunekStudiow = "Informatyka Przemysłowa",
                            Mail = "milosz.malecki@student.pl",
                            Nazwisko = "Malecki",
                            NrTelefonu = "789-666-231",
                            Uczelnia = "Politechnika Śląska",
                            Wydzial = "Inżynierii Materiałowej"
                        });
                });

            modelBuilder.Entity("DAL.PelnionaFunkcja", b =>
                {
                    b.Property<int>("IdPelnionejFunkcji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPelnionejFunkcji"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPelnionejFunkcji");

                    b.ToTable("PelnioneFunkcje");

                    b.HasData(
                        new
                        {
                            IdPelnionejFunkcji = 1,
                            Nazwa = "Lider projektu"
                        },
                        new
                        {
                            IdPelnionejFunkcji = 2,
                            Nazwa = "Koordynator wydarzenia"
                        });
                });

            modelBuilder.Entity("DAL.Projekt", b =>
                {
                    b.Property<int>("IdProjektu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProjektu"));

                    b.Property<int>("IdZespolu")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("TerminRealizacji")
                        .HasColumnType("datetime2");

                    b.HasKey("IdProjektu");

                    b.HasIndex("IdZespolu");

                    b.ToTable("Projekty");

                    b.HasData(
                        new
                        {
                            IdProjektu = 1,
                            IdZespolu = 1,
                            Nazwa = "Mapa wydziału",
                            Opis = "Projekt mapy Wydziału",
                            TerminRealizacji = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdProjektu = 2,
                            IdZespolu = 2,
                            Nazwa = "Ramiee robota",
                            Opis = "Projekt ramienia robota",
                            TerminRealizacji = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DAL.Sprzet", b =>
                {
                    b.Property<int>("IdSprzetu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSprzetu"));

                    b.Property<bool>("CzyDostepny")
                        .HasColumnType("bit");

                    b.Property<int>("IdCzlonka")
                        .HasColumnType("int");

                    b.Property<int>("IdZespolu")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("IdSprzetu");

                    b.HasIndex("IdCzlonka");

                    b.HasIndex("IdZespolu");

                    b.ToTable("Sprzety");

                    b.HasData(
                        new
                        {
                            IdSprzetu = 1,
                            CzyDostepny = true,
                            IdCzlonka = 1,
                            IdZespolu = 1,
                            Nazwa = "Lutownica",
                            Opis = "Lutownica służy do lutowania"
                        },
                        new
                        {
                            IdSprzetu = 2,
                            CzyDostepny = true,
                            IdCzlonka = 2,
                            IdZespolu = 2,
                            Nazwa = "Arduino UNO",
                            Opis = "Arduino UNO służy do wielu rzeczy"
                        });
                });

            modelBuilder.Entity("DAL.Wydarzenie", b =>
                {
                    b.Property<int>("IdWydarzenia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWydarzenia"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdZespolu")
                        .HasColumnType("int");

                    b.Property<string>("Miejsce")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdWydarzenia");

                    b.HasIndex("IdZespolu");

                    b.ToTable("Wydarzenia");

                    b.HasData(
                        new
                        {
                            IdWydarzenia = 1,
                            Data = new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdZespolu = 1,
                            Miejsce = "Katowice MCK",
                            Nazwa = "Śląski Festiwal Nauki"
                        },
                        new
                        {
                            IdWydarzenia = 2,
                            Data = new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdZespolu = 2,
                            Miejsce = "PIK",
                            Nazwa = "Noc Naukowców Politechniki Śląskiej"
                        });
                });

            modelBuilder.Entity("DAL.Zespol", b =>
                {
                    b.Property<int>("IdZespolu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZespolu"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdZespolu");

                    b.ToTable("Zespoly");

                    b.HasData(
                        new
                        {
                            IdZespolu = 1,
                            Nazwa = "Zespół projektowy nr 1"
                        },
                        new
                        {
                            IdZespolu = 2,
                            Nazwa = "Zespół projektowy nr 2"
                        });
                });

            modelBuilder.Entity("CzlonekZespol", b =>
                {
                    b.HasOne("DAL.Czlonek", null)
                        .WithMany()
                        .HasForeignKey("CzlonkowieIdCzlonka")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Zespol", null)
                        .WithMany()
                        .HasForeignKey("ZespolyIdZespolu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Czlonek", b =>
                {
                    b.HasOne("DAL.PelnionaFunkcja", "PelnionaFunkcja")
                        .WithMany("Czlonkowie")
                        .HasForeignKey("IdPelnionejFunkcji")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PelnionaFunkcja");
                });

            modelBuilder.Entity("DAL.Projekt", b =>
                {
                    b.HasOne("DAL.Zespol", "Zespol")
                        .WithMany("Projekty")
                        .HasForeignKey("IdZespolu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zespol");
                });

            modelBuilder.Entity("DAL.Sprzet", b =>
                {
                    b.HasOne("DAL.Czlonek", "Czlonek")
                        .WithMany("Sprzety")
                        .HasForeignKey("IdCzlonka")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Zespol", "Zespol")
                        .WithMany("Sprzety")
                        .HasForeignKey("IdZespolu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Czlonek");

                    b.Navigation("Zespol");
                });

            modelBuilder.Entity("DAL.Wydarzenie", b =>
                {
                    b.HasOne("DAL.Zespol", "Zespol")
                        .WithMany("Wydarzenia")
                        .HasForeignKey("IdZespolu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zespol");
                });

            modelBuilder.Entity("DAL.Czlonek", b =>
                {
                    b.Navigation("Sprzety");
                });

            modelBuilder.Entity("DAL.PelnionaFunkcja", b =>
                {
                    b.Navigation("Czlonkowie");
                });

            modelBuilder.Entity("DAL.Zespol", b =>
                {
                    b.Navigation("Projekty");

                    b.Navigation("Sprzety");

                    b.Navigation("Wydarzenia");
                });
#pragma warning restore 612, 618
        }
    }
}
