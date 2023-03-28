using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbKoloNaukoweERP : DbContext
    {
        public DbSet<Czlonek> Czlonkowie { get; set; }
        public DbSet<PelnionaFunkcja> PelnioneFunkcje { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Wydarzenie> Wydarzenia { get; set; }
        public DbSet<Zespol> Zespoly { get; set; }
        public DbSet<Projekt> Projekty { get; set; }
        //public DbSet<CzlonekZespol> CzlonkowieZespoly { get; set; }

        public DbKoloNaukoweERP(DbContextOptions<DbKoloNaukoweERP> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Czlonek> czlonkowie = new List<Czlonek>
            {
                new Czlonek
                {
                    IdCzlonka = 1,
                    IdPelnionejFunkcji = 1,
                    //IdCzlonekZespol = 1,
                    NrTelefonu = "696-789-521",
                    Mail = "daniel.malik@student.pl",
                    Nazwisko = "Malik",
                    Imie = "Daniel",
                    KierunekStudiow = "Informatyka Przemysłowa",
                    Wydzial = "Inżynierii Materiałowej",
                    Uczelnia = "Politechnika Śląska"
                },
                new Czlonek
                {
                    IdCzlonka = 2,
                    IdPelnionejFunkcji = 2,
                    //IdCzlonekZespol = 2,
                    NrTelefonu = "789-666-231",
                    Mail = "milosz.malecki@student.pl",
                    Nazwisko = "Malecki",
                    Imie = "Milosz",
                    KierunekStudiow = "Informatyka Przemysłowa",
                    Wydzial = "Inżynierii Materiałowej",
                    Uczelnia = "Politechnika Śląska"
                }
            };

            List<PelnionaFunkcja> pelnioneFunkcje = new List<PelnionaFunkcja>
            {
                new PelnionaFunkcja
                {
                    IdPelnionejFunkcji = 1,
                    Nazwa = "Lider projektu"
                },
                new PelnionaFunkcja
                {
                    IdPelnionejFunkcji = 2,
                    Nazwa = "Koordynator wydarzenia"
                }
            };

            List<Sprzet> sprzety = new List<Sprzet>
            {
                new Sprzet
                {
                    IdSprzetu = 1,
                    IdCzlonka = 1,
                    IdZespolu = 1,
                    Nazwa = "Lutownica",
                    Opis = "Lutownica służy do lutowania",
                    CzyDostepny = true
                },
                new Sprzet
                {
                    IdSprzetu = 2,
                    IdCzlonka = 2,
                    IdZespolu = 2,
                    Nazwa = "Arduino UNO",
                    Opis = "Arduino UNO służy do wielu rzeczy",
                    CzyDostepny = true
                }
            };

            List<Wydarzenie> wydarzenia = new List<Wydarzenie>
            {
                new Wydarzenie
                {
                    IdWydarzenia = 1,
                    IdZespolu = 1,
                    Nazwa = "Śląski Festiwal Nauki",
                    Data = new DateTime(2023, 12, 8),
                    Miejsce = "Katowice MCK"
                },
                new Wydarzenie
                {
                    IdWydarzenia = 2,
                    IdZespolu = 2,
                    Nazwa = "Noc Naukowców Politechniki Śląskiej",
                    Data = new DateTime(2023, 10, 8),
                    Miejsce = "PIK"
                }
            };

            List<Projekt> projekty = new List<Projekt>
            {
                new Projekt
                {
                    IdProjektu = 1,
                    IdZespolu = 1,
                    Nazwa = "Mapa wydziału",
                    TerminRealizacji = new DateTime(2024, 01, 1),
                    Opis = "Projekt mapy Wydziału"
                },
                new Projekt
                {
                    IdProjektu = 2,
                    IdZespolu = 2,
                    Nazwa = "Ramiee robota",
                    TerminRealizacji = new DateTime(2025, 01, 1),
                    Opis = "Projekt ramienia robota"
                }
            };

            List<Zespol> zespoly = new List<Zespol>
            {
                new Zespol
                {
                    IdZespolu = 1,
                   /* IdProjektu = 1,*/
/*                    IdWydarzenia = 1,*/
                    //IdCzlonekZespol = 1,
                    Nazwa = "Zespół projektowy nr 1",
                },
                new Zespol
                {
                    IdZespolu = 2,
                   /* IdProjektu = 2,*/
/*                    IdWydarzenia = 2,*/
                    //IdCzlonekZespol = 2,
                    Nazwa = "Zespół projektowy nr 2",
                }
            };

            //List<CzlonekZespol> czlonkowieZespoly = new List<CzlonekZespol>
            //{
            //    new CzlonekZespol
            //    {
            //        IdCzlonekZespol = 1,
            //        IdCzlonka = 1,
            //        IdZespolu=1
            //    },
            //    new CzlonekZespol
            //    {
            //        IdCzlonekZespol = 2,
            //        IdCzlonka= 2,
            //        IdZespolu=2
            //    },
            //};

            modelBuilder.Entity<Czlonek>()
                .HasData(czlonkowie);

            modelBuilder.Entity<PelnionaFunkcja>()
                .HasData(pelnioneFunkcje);

            modelBuilder.Entity<Sprzet>()
                .HasData(sprzety);

            modelBuilder.Entity<Wydarzenie>()
                .HasData(wydarzenia);

            modelBuilder.Entity<Projekt>()
                .HasData(projekty);

            modelBuilder.Entity<Zespol>()
                .HasData(zespoly);

            //modelBuilder.Entity<CzlonekZespol>()
            //    .HasData(czlonkowieZespoly);
        }
    }
}
