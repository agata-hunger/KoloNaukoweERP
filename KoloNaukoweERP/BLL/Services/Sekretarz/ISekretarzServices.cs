﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Sekretarz
{
    public interface ISekretarzServices
    {
        void AddCzlonek(string nazwaPelnionejFunkcji, string nrTelefonu, string mail, string nazwisko, string imie, string kierunekStudiow, string wydzial, string uczelnia, ICollection<Zespol> zespoly, ICollection<Sprzet> sprzety);
        void RemoveCzlonek(string nazwiskoCzlonka, string imieCzlonka);

        void AddZespol(string nazwaZespolu, ICollection<Czlonek> czlonkowie, ICollection<Sprzet> sprzety, ICollection<Projekt> projekty, ICollection<Wydarzenie> wydarzenia);
        void RemoveZespol(string nazwaZespolu);

        void AddWydarzenie(string nazwaWydarzenia, string nazwaZespolu, DateTime dataWydarzenia, string miejsceWydarzenia);
        void RemoveWydarzenie(string nazwaWydarzenia);

        void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);
        void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);

        void AddCzlonekToTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka);
        void RemoveCzlonekFromTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka);

        void AddWydarzenieToTeam(string nazwaZespolu, string nazwaWydarzenia);
        void RemoveWydarzenieFromTeam(string nazwaZespolu, string nazwaWydarzenia);

        void AddProjektToTeam(string nazwaZespolu, string nazwaProjektu);
        void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu);

        void AddZespolToProject(Zespol zespol, string nazwaProjektu);
        void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu);

        void AddZespolToEvent(Zespol zespol, string nazwaWydarzenia);
        void RemoveZespolFromEvent(Zespol zespol, string nazwaWydarzenia);

        void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja);
        void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka);

        void AddPelnionaFunkcja(string nazwaPelnionejFunkcji, ICollection<Czlonek> czlonkowie);
        void RemovePelnionaFunkcja(string nazwaPelnionejFunkcji);

        void AddSprzet(string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu, string nazwaSprzetu, string opis, bool czyDostepny);
        void RemoveSprzet(string nazwaSprzetu);

        void AddProjekt(string nazwaProjektu, string nazwaZespolu, DateTime terminRealizacji, string opisWydarzenia);
        void RemoveProjekt(string nazwaProjektu);

        Wydarzenie GetEvent(int idWydarzenia);
        List<Wydarzenie> GetEvents();
        Zespol GetTeam(int idWydarzenia);
        List<Zespol> GetTeams();
        //void EditEvent(int idWydarzenia);

    }
}
