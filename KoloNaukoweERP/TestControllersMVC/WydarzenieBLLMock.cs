using System;
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

        public void AddCzlonek(PelnionaFunkcja nazwaPelnionejFunkcji, string nrTelefonu, string mail, string nazwisko, string imie, string kierunekStudiow, string wydzial, string uczelnia, ICollection<Zespol> zespoly, ICollection<Sprzet> sprzety)
        {
            throw new NotImplementedException();
        }

        public void RemoveCzlonek(int idCzlonka)
        {
            throw new NotImplementedException();
        }

        public void AddZespol(string nazwaZespolu, ICollection<Czlonek> czlonkowie, ICollection<Sprzet> sprzety, ICollection<Projekt> projekty, ICollection<Wydarzenie> wydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespol(int idZespolu)
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

        public void AddSprzetToTeam(int idZespolu, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void AddSprzet(string nazwaSprzetu, string opis, bool czyDostepny)
        {
            throw new NotImplementedException();
        }

        public void RemoveSprzet(int idSprzetu)
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

        public void AddWydarzenieToTeam(int idZespolu, Wydarzenie wydarzenie)
        {
            throw new NotImplementedException();
        }

        public void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
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

        public IEnumerable<Wydarzenie> GetEvents()
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

        public void RemoveWydarzenieFromTeam(int idZespolu, Wydarzenie wydarzenie)
        {
            throw new NotImplementedException();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespolFromEvent(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu)
        {
            throw new NotImplementedException();
        }

        public void InsertWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {

            throw new NotImplementedException();
        }
        public void DeleteWydarzenie(int? idWydarzenia)
        {
            throw new NotImplementedException();
        }
        public void AddZespolToEvent(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
        public void DeleteZespol(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
    }
}
