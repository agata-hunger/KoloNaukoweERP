using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PelnioneFunkcje",
                columns: table => new
                {
                    IdPelnionejFunkcji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PelnioneFunkcje", x => x.IdPelnionejFunkcji);
                });

            migrationBuilder.CreateTable(
                name: "Zespoly",
                columns: table => new
                {
                    IdZespolu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zespoly", x => x.IdZespolu);
                });

            migrationBuilder.CreateTable(
                name: "Czlonkowie",
                columns: table => new
                {
                    IdCzlonka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPelnionejFunkcji = table.Column<int>(type: "int", nullable: true),
                    NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KierunekStudiow = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wydzial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Uczelnia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czlonkowie", x => x.IdCzlonka);
                    table.ForeignKey(
                        name: "FK_Czlonkowie_PelnioneFunkcje_IdPelnionejFunkcji",
                        column: x => x.IdPelnionejFunkcji,
                        principalTable: "PelnioneFunkcje",
                        principalColumn: "IdPelnionejFunkcji",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    IdProjektu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZespolu = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TerminRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.IdProjektu);
                    table.ForeignKey(
                        name: "FK_Projekty_Zespoly_IdZespolu",
                        column: x => x.IdZespolu,
                        principalTable: "Zespoly",
                        principalColumn: "IdZespolu");
                });

            migrationBuilder.CreateTable(
                name: "Wydarzenia",
                columns: table => new
                {
                    IdWydarzenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZespolu = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Miejsce = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenia", x => x.IdWydarzenia);
                    table.ForeignKey(
                        name: "FK_Wydarzenia_Zespoly_IdZespolu",
                        column: x => x.IdZespolu,
                        principalTable: "Zespoly",
                        principalColumn: "IdZespolu");
                });

            migrationBuilder.CreateTable(
                name: "CzlonekZespol",
                columns: table => new
                {
                    CzlonkowieIdCzlonka = table.Column<int>(type: "int", nullable: false),
                    ZespolyIdZespolu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzlonekZespol", x => new { x.CzlonkowieIdCzlonka, x.ZespolyIdZespolu });
                    table.ForeignKey(
                        name: "FK_CzlonekZespol_Czlonkowie_CzlonkowieIdCzlonka",
                        column: x => x.CzlonkowieIdCzlonka,
                        principalTable: "Czlonkowie",
                        principalColumn: "IdCzlonka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CzlonekZespol_Zespoly_ZespolyIdZespolu",
                        column: x => x.ZespolyIdZespolu,
                        principalTable: "Zespoly",
                        principalColumn: "IdZespolu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    IdSprzetu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCzlonka = table.Column<int>(type: "int", nullable: true),
                    IdZespolu = table.Column<int>(type: "int", nullable: true),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CzyDostepny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.IdSprzetu);
                    table.ForeignKey(
                        name: "FK_Sprzety_Czlonkowie_IdCzlonka",
                        column: x => x.IdCzlonka,
                        principalTable: "Czlonkowie",
                        principalColumn: "IdCzlonka");
                    table.ForeignKey(
                        name: "FK_Sprzety_Zespoly_IdZespolu",
                        column: x => x.IdZespolu,
                        principalTable: "Zespoly",
                        principalColumn: "IdZespolu");
                });

            migrationBuilder.InsertData(
                table: "PelnioneFunkcje",
                columns: new[] { "IdPelnionejFunkcji", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Lider projektu" },
                    { 2, "Koordynator wydarzenia" }
                });

            migrationBuilder.InsertData(
                table: "Zespoly",
                columns: new[] { "IdZespolu", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Zespół projektowy nr 1" },
                    { 2, "Zespół projektowy nr 2" }
                });

            migrationBuilder.InsertData(
                table: "Czlonkowie",
                columns: new[] { "IdCzlonka", "IdPelnionejFunkcji", "Imie", "KierunekStudiow", "Mail", "Nazwisko", "NrTelefonu", "Uczelnia", "Wydzial" },
                values: new object[,]
                {
                    { 1, 1, "Daniel", "Informatyka Przemysłowa", "daniel.malik@student.pl", "Malik", "696-789-521", "Politechnika Śląska", "Inżynierii Materiałowej" },
                    { 2, 2, "Milosz", "Informatyka Przemysłowa", "milosz.malecki@student.pl", "Malecki", "789-666-231", "Politechnika Śląska", "Inżynierii Materiałowej" }
                });

            migrationBuilder.InsertData(
                table: "Projekty",
                columns: new[] { "IdProjektu", "IdZespolu", "Nazwa", "Opis", "TerminRealizacji" },
                values: new object[,]
                {
                    { 1, 1, "Mapa wydziału", "Projekt mapy Wydziału", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Ramiee robota", "Projekt ramienia robota", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Wydarzenia",
                columns: new[] { "IdWydarzenia", "Data", "IdZespolu", "Miejsce", "Nazwa" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Katowice MCK", "Śląski Festiwal Nauki" },
                    { 2, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "PIK", "Noc Naukowców Politechniki Śląskiej" }
                });

            migrationBuilder.InsertData(
                table: "Sprzety",
                columns: new[] { "IdSprzetu", "CzyDostepny", "IdCzlonka", "IdZespolu", "Nazwa", "Opis" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "Lutownica", "Lutownica służy do lutowania" },
                    { 2, true, 2, 2, "Arduino UNO", "Arduino UNO służy do wielu rzeczy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CzlonekZespol_ZespolyIdZespolu",
                table: "CzlonekZespol",
                column: "ZespolyIdZespolu");

            migrationBuilder.CreateIndex(
                name: "IX_Czlonkowie_IdPelnionejFunkcji",
                table: "Czlonkowie",
                column: "IdPelnionejFunkcji");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_IdZespolu",
                table: "Projekty",
                column: "IdZespolu");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzety_IdCzlonka",
                table: "Sprzety",
                column: "IdCzlonka");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzety_IdZespolu",
                table: "Sprzety",
                column: "IdZespolu");

            migrationBuilder.CreateIndex(
                name: "IX_Wydarzenia_IdZespolu",
                table: "Wydarzenia",
                column: "IdZespolu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CzlonekZespol");

            migrationBuilder.DropTable(
                name: "Projekty");

            migrationBuilder.DropTable(
                name: "Sprzety");

            migrationBuilder.DropTable(
                name: "Wydarzenia");

            migrationBuilder.DropTable(
                name: "Czlonkowie");

            migrationBuilder.DropTable(
                name: "Zespoly");

            migrationBuilder.DropTable(
                name: "PelnioneFunkcje");
        }
    }
}
