﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Sekretarz;
using DAL;
using DAL.Entities;

namespace TestControllersMVC
{
    public class WydarzenieBLLMock : ISekretarzServices
    {
        public string NazwaWydarzenia;
        public string NazwaZespolu;
        public DateTime DataWydarzenia;
        public string MiejsceWydarzenia;

        public void AddCzlonek(string nazwaPelnionejFunkcji, string nrTelefonu, string mail, string nazwisko, string imie, string kierunekStudiow, string wydzial, string uczelnia, ICollection<Zespol> zespoly, ICollection<Sprzet> sprzety)
        {
            throw new NotImplementedException();
        }

        public void AddCzlonekToTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka)
        {
            throw new NotImplementedException();
        }

        public void AddPelnionaFunkcja(string nazwaPelnionejFunkcji, ICollection<Czlonek> czlonkowie)
        {
            throw new NotImplementedException();
        }

        public void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void AddProjekt(string nazwaProjektu, string nazwaZespolu, DateTime terminRealizacji, string opisWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddProjektToTeam(string nazwaZespolu, string nazwaProjektu)
        {
            throw new NotImplementedException();
        }

        public void AddSprzet(string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu, string nazwaSprzetu, string opis, bool czyDostepny)
        {
            throw new NotImplementedException();
        }

        public void AddWydarzenie(string nazwaWydarzenia, string nazwaZespolu, DateTime dataWydarzenia, string miejsceWydarzenia)
        {
            NazwaWydarzenia = nazwaWydarzenia;
            NazwaZespolu = nazwaZespolu;
            DataWydarzenia = dataWydarzenia;
            MiejsceWydarzenia = miejsceWydarzenia;
        }

        public void AddWydarzenieToTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
        {
            throw new NotImplementedException();
        }

        public void AddZespol(string nazwaZespolu, ICollection<Czlonek> czlonkowie, ICollection<Sprzet> sprzety, ICollection<Projekt> projekty, ICollection<Wydarzenie> wydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddZespolToEvent(Zespol zespol, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddZespolToProject(Zespol zespol, string nazwaProjektu)
        {
            throw new NotImplementedException();
        }

        public Wydarzenie GetEvent(int idWydarzenia)
        {
            throw new NotImplementedException();
        }

        public List<Wydarzenie> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Zespol GetTeam(int idWydarzenia)
        {
            //var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            //return zespol;

            List<Zespol> zespolList = new List<Zespol>
            {
                new Zespol
                {
                    IdZespolu = 1
                }
            };
            return zespolList.ElementAt(idWydarzenia);
        }

        public List<Zespol> GetTeams()
        {
            throw new NotImplementedException();
        }

        public void RemoveCzlonek(string nazwiskoCzlonka, string imieCzlonka)
        {
            throw new NotImplementedException();
        }

        public void RemoveCzlonekFromTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka)
        {
            throw new NotImplementedException();
        }

        public void RemovePelnionaFunkcja(string nazwaPelnionejFunkcji)
        {
            throw new NotImplementedException();
        }

        public void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka)
        {
            throw new NotImplementedException();
        }

        public void RemoveProjekt(string nazwaProjektu)
        {
            throw new NotImplementedException();
        }

        public void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu)
        {
            throw new NotImplementedException();
        }

        public void RemoveSprzet(string nazwaSprzetu)
        {
            throw new NotImplementedException();
        }

        public void RemoveWydarzenie(string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveWydarzenieFromTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespol(string nazwaZespolu)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespolFromEvent(Zespol zespol, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu)
        {
            throw new NotImplementedException();
        }
    }
}
