using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Sekretarz
{
    public interface ISekretarzServices
    {
        void AddCzlonek(Czlonek czlonek);
        void RemoveCzlonek(int idCzlonka);

        void AddCzlonekToTeam(int idZespolu, Czlonek czlonek);
        void RemoveCzlonekFromTeam(int idZespolu, Czlonek czlonek);

        void AddZespol(Zespol zespol);
        void RemoveZespol(int idZespolu);

        /*void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);
        void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);*/

        void AddWydarzenie(Wydarzenie wydarzenie);
        void RemoveWydarzenie(string nazwaWydarzenia);

        void AddWydarzenieToTeam(int idZespolu, Wydarzenie wydarzenie);
        void RemoveWydarzenieFromTeam(int idZespolu, Wydarzenie wydarzenie);

        void AddProjektToTeam(int idZespolu, Projekt projekt);
        void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu);

        void AddZespolToProject(Zespol zespol, string nazwaProjektu);
        void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu);

        void AddZespolToEvent(int idWydarzenia, Zespol zespol);
        void RemoveZespolFromEvent(int idWydarzenia, Zespol zespol);

        void AddPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja);
        void RemovePelnionaFunkcja(string nazwaPelnionejFunkcji);

        void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja);
        void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka);

        void AddSprzet(Sprzet sprzet);
        void RemoveSprzet(int idSrzetu);

        void AddSprzetToTeam(int idZespolu, Sprzet sprzet);
        void RemoveSprzetFromTeam(int idZespolu, Sprzet sprzet);

        void AddProjekt(Projekt projekt);
        void RemoveProjekt(int idProjektu);

        Wydarzenie GetEvent(int idWydarzenia);
        IEnumerable<Wydarzenie> GetEvents();
        Zespol GetTeam(int idWydarzenia);
        List<Zespol> GetTeams();
        //void EditEvent(int idWydarzenia);


        /*
        co można dodać i nawet może miałoby sens

        - przy metodach np. DeleteCzlonekFromTeam trzeba przesyłać też idZespolu a nie tylko czlonka

        - czy to nie jest to samo?	
            -> void AddProjektToTeam(string nazwaZespolu, string nazwaProjektu);
            -> void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu);
           + 
            void AddZespolToProject(Zespol zespol, string nazwaProjektu);
            void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu);

        - czy to nie jest to samo?
            void AddZespolToEvent(int idWydarzenia, Zespol zespol);
            void RemoveZespolFromEvent(int idWydarzenia, Zespol zespol);
           +
            -> void AddWydarzenieToTeam(int idZespolu, Wydarzenie wydarzenie);
            -> void RemoveWydarzenieFromTeam(int idZespolu, Wydarzenie wydarzenie);

        - czy AddPelnionaFunkcja(string nazwaPelnionejFunkcji, ICollection<Czlonek> czlonkowie)
            powinna mieć kolekcje jako argument?

        - addZespol
        - removeZespol

        */
    }
}