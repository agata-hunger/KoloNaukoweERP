﻿using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Sekretarz
{
    public class SekretarzeServices : ISekretarzServices
    {
        private readonly IUnitOfWork unitOfWork;
        public SekretarzeServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddZespol(string nazwaZespolu, ICollection<Czlonek> czlonkowie, ICollection<Sprzet> sprzety, ICollection<Projekt> projekty, ICollection<Wydarzenie> wydarzenia)
        {
            Zespol zespol = new Zespol();
            zespol.Nazwa = nazwaZespolu;
            zespol.Czlonkowie = czlonkowie;
            zespol.Sprzety = sprzety;
            zespol.Projekty = projekty;
            zespol.Wydarzenia = wydarzenia;
            unitOfWork.Zespoly.InsertZespol(zespol);
            unitOfWork.Save();
        }

        public void RemoveZespol(string nazwaZespolu)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var idZespolu = zespol.IdZespolu;
            unitOfWork.Zespoly.DeleteZespol(idZespolu);
            unitOfWork.Save();
        }

        public void AddWydarzenie(string nazwaWydarzenia, string nazwaZespolu, DateTime dataWydarzenia, string miejsceWydarzenia)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            Wydarzenie wydarzenie = new Wydarzenie();
            wydarzenie.Nazwa = nazwaWydarzenia;
            wydarzenie.Zespol = zespol;
            wydarzenie.Data = dataWydarzenia;
            wydarzenie.Miejsce = miejsceWydarzenia;
            unitOfWork.Wydarzenia.InsertWydarzenie(wydarzenie);
            unitOfWork.Save();
        }

        public void RemoveWydarzenie(string nazwaWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            if (wydarzenie != null)
            {
                var idWydarzenia = wydarzenie.IdWydarzenia;
                unitOfWork.Wydarzenia.DeleteWydarzenie(idWydarzenia);
            }
            unitOfWork.Save();
        }

        public void AddCzlonek(string nazwaPelnionejFunkcji, string nrTelefonu, string mail, string nazwisko, string imie, string kierunekStudiow, string wydzial, string uczelnia, ICollection<Zespol> zespoly, ICollection<Sprzet> sprzety)
        {
            var pelnionaFunkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(pelnionaFunkcja => pelnionaFunkcja.Nazwa.Equals(nazwaPelnionejFunkcji));
            Czlonek czlonek = new Czlonek();
            czlonek.PelnionaFunkcja = pelnionaFunkcja;
            czlonek.NrTelefonu = nrTelefonu;
            czlonek.Mail = mail;
            czlonek.Nazwisko = nazwisko;
            czlonek.Imie = imie;
            czlonek.Uczelnia = uczelnia;
            czlonek.KierunekStudiow = kierunekStudiow;
            czlonek.Wydzial = wydzial;
            czlonek.Zespoly = zespoly;
            czlonek.Sprzety = sprzety;
            unitOfWork.Czlonkowie.InsertCzlonek(czlonek);
            unitOfWork.Save();
        }

        public void RemoveCzlonek(string nazwiskoCzlonka, string imieCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Nazwisko.Equals(nazwiskoCzlonka) && czlonek.Imie.Equals(imieCzlonka));
            var idCzlonka = czlonek.IdCzlonka;
            unitOfWork.Czlonkowie.DeleteCzlonek(idCzlonka);
            unitOfWork.Save();
        }

        public void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Nazwisko.Equals(nazwiskoCzlonka) && czlonek.Imie.Equals(imieCzlonka));
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            if (czlonek != null && zespol == null)
            {
                czlonek.Sprzety.Add(sprzet);
            }
            else
            {
                zespol.Sprzety.Add(sprzet);
            }
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Nazwisko.Equals(nazwiskoCzlonka) && czlonek.Imie.Equals(imieCzlonka));
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            if (czlonek != null && zespol == null)
            {
                czlonek.Sprzety.Remove(sprzet);
            }
            else
            {
                zespol.Sprzety.Remove(sprzet);
            }
            unitOfWork.Save();
        }

        public void AddCzlonekToTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            if (czlonek != null)
            {
                zespol.Czlonkowie.Add(czlonek);
            }
            unitOfWork.Save();
        }

        public void RemoveCzlonekFromTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            if (czlonek != null)
            {
                zespol.Czlonkowie.Remove(czlonek);
            }
            unitOfWork.Save();
        }

        public void AddWydarzenieToTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            if (wydarzenie != null)
            {
                zespol.Wydarzenia.Add(wydarzenie);
            }
            unitOfWork.Save();
        }

        public void RemoveWydarzenieFromTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            if (wydarzenie != null)
            {
                zespol.Wydarzenia.Remove(wydarzenie);
            }
            unitOfWork.Save();
        }

        public void AddProjektToTeam(string nazwaZespolu, string nazwaProjektu)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            if (projekt != null)
            {
                zespol.Projekty.Add(projekt);
            }
            unitOfWork.Save();
        }


        public void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            if (projekt != null)
            {
                zespol.Projekty.Remove(projekt);
            }
            unitOfWork.Save();
        }

        public void AddZespolToProject(Zespol zespol, string nazwaProjektu)
        {
            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            projekt.Zespol = zespol;
            unitOfWork.Save();
        }

        public void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu)
        {
            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            projekt.Zespol = null;
            unitOfWork.Save();
        }

        public void AddZespolToEvent(Zespol zespol, string nazwaWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            wydarzenie.Zespol = zespol;
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(Zespol zespol, string nazwaWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            wydarzenie.Zespol = null;
            unitOfWork.Save();
        }

        public void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            var funkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(pelnionaFunkcja => pelnionaFunkcja.Nazwa.Equals(pelnionaFunkcja));
            if (czlonek != null && funkcja != null)
            {
                czlonek.PelnionaFunkcja = funkcja;
            }
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            if (czlonek != null)
            {
                czlonek.PelnionaFunkcja = null; //It can be null because IdPelnionejFunkcji in Czlonek is nullable
            }
            unitOfWork.Save();
        }

        public void AddPelnionaFunkcja(string nazwaPelnionejFunkcji, ICollection<Czlonek> czlonkowie)
        {
            PelnionaFunkcja pelnionaFunkcja = new PelnionaFunkcja();
            pelnionaFunkcja.Nazwa = nazwaPelnionejFunkcji;
            pelnionaFunkcja.Czlonkowie = czlonkowie;
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcja(string nazwaPelnionejFunkcji)
        {
            var funkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(funkcja => funkcja.Nazwa.Equals(nazwaPelnionejFunkcji));
            var funkcjaId = funkcja.IdPelnionejFunkcji;
            if (funkcja !=null)
            {
                unitOfWork.PelnioneFunkcje.DeletePelnionaFunkcja(funkcjaId);
            }
        }

        public void AddSprzet(string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu, string nazwaSprzetu, string opis, bool czyDostepny)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Nazwisko.Equals(nazwiskoCzlonka) && czlonek.Imie.Equals(imieCzlonka));
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));

            Sprzet sprzet = new Sprzet();
            sprzet.Nazwa = nazwaSprzetu;
            sprzet.Czlonek = czlonek;
            sprzet.Zespol = zespol;
            sprzet.Opis = opis;
            sprzet.CzyDostepny = czyDostepny;
            unitOfWork.Save();
        }

        public void RemoveSprzet(string nazwaSprzetu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var SprzetId = sprzet.IdSprzetu;
            if(sprzet != null)
            {
                unitOfWork.Sprzety.DeleteSprzet(SprzetId);
            }
        }
        public void AddProjekt(string nazwaProjektu, string nazwaZespolu, DateTime terminRealizacji, string opisWydarzenia)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            Projekt projekt = new Projekt();
            projekt.Nazwa = nazwaProjektu;
            projekt.Zespol = zespol;
            projekt.TerminRealizacji = terminRealizacji;
            projekt.Opis = opisWydarzenia;
            unitOfWork.Projekty.InsertProjekt(projekt);
            unitOfWork.Save();
        }
        public void RemoveProjekt(string nazwaProjektu)
        {
            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            var projektId = projekt.IdProjektu;
            unitOfWork.Projekty.DeleteProjekt(projektId);
            unitOfWork.Save();
        }
        public Wydarzenie GetEvent(int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            return wydarzenie;
        }
        public List<Wydarzenie> GetEvents()
        {
            var list = new List<Wydarzenie>();
            list = (List<Wydarzenie>)unitOfWork.Wydarzenia.GetWydarzenia();   //w razie czego sprawdzić typ!
            return list;
        }
        public Zespol GetTeam(int idZespolu)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            return zespol;
        }
        public List<Zespol> GetTeams()
        {
            var list = new List<Zespol>();
            list = (List<Zespol>)unitOfWork.Zespoly.GetZespoly();
            return list;
        }
        
    }
}
