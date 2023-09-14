using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services.Sekretarz
{
    public interface ISekretarzServices
    {
        void AddCzlonek(CzlonekDTO czlonekDto);
        void RemoveCzlonek(int idCzlonka);

        void AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto);
        void RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto);

        void AddZespol(ZespolDTO zespolDto);
        void RemoveZespol(int? idZespolu);

        /*void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);
        void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);*/

        void AddWydarzenie(WydarzenieDTO wydarzenieDto);
        void RemoveWydarzenie(int idWydarzenia);

        void AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto);
        void RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto);

        void AddProjektToTeam(int idZespolu, ProjektDTO projektDto);
        void RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDto);

        void AddZespolToProject(int idProjektu, ZespolDTO zespolDto);
        void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto);       //ddpd

        void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto);
        void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto);

        void AddPelnionaFunkcja(PelnionaFunkcjaDTO pelnionaFunkcjaDto);
        void RemovePelnionaFunkcja(int? idPelnionejFunkcji);

        void AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto);
        void RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto);

        void AddSprzet(SprzetDTO sprzetDto);
        void RemoveSprzet(int? idSrzetu);

        void AddSprzetToTeam(int idZespolu, SprzetDTO sprzetDto);
        void RemoveSprzetFromTeam(int idZespolu, SprzetDTO sprzetDto);

        void AddProjekt(ProjektDTO projektDto);
        void RemoveProjekt(int idProjektu);

        WydarzenieDTO GetEvent(int idWydarzenia);
        IEnumerable<WydarzenieDTO> GetEvents();
        ZespolDTO GetTeam(int idZespolu);
        List<ZespolDTO> GetTeams();

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