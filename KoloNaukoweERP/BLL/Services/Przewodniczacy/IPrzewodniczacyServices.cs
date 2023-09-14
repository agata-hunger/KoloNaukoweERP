using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ZastepcaPrzewodniczacego
{
    public interface IPrzewodniczacyServices
    {
        void AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcja);
        void RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcja);

        void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);

        void AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto);
        void RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto);

        void AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto);
        void RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto);

        void AddProjektToTeam(int idZespolu, ProjektDTO projektDt);
        void RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDt);

        void AddZespolToProject(int idProjektu, ZespolDTO zespolDto);
        void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto);

        void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto);
        void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto);

       
    }
}
