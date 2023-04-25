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
        void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja);
        void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka);

        //TODO: ujednolicić - opcjonalnie
        void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);
        void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu);

        void AddCzlonekToTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka);
        void RemoveCzlonekFromTeam(Zespol zespol, string imieCzlonka, string nazwiskoCzlonka);


        void AddEventToTeam(string nazwaZespolu, string nazwaWydarzenia);
        void RemoveEventFromTeam(string nazwaZespolu, string nazwaWydarzenia);


        void AddProjektToTeam(string nazwaZespolu, string nazwaProjektu);
        void RemoveProjektFromTeam(string nazwaZespolu, string nazwaProjektu);

        void AddZespolToProject(Zespol zespol, string nazwaProjektu);
        void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu);

        void AddZespolToEvent(Zespol zespol, string nazwaWydarzenia);
        void RemoveZespolFromEvent(Zespol zespol, string nazwaWydarzenia);

       
    }
}
