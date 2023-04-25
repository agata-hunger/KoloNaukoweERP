using BLL.Services.Koordynator;
using BLL.Services.Lider;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ZastepcaPrzewodniczacego
{
    public class PrzewodniczacyServices : IPrzewodniczacyServices
    {
        private readonly IUnitOfWork unitOfWork;
        public PrzewodniczacyServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void AddPelnionaFunkcjaToUser(string imieCzlonka, string nazwiskoCzlonka, string pelnionaFunkcja)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            var funkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(pelnionaFunkcja => pelnionaFunkcja.Nazwa.Equals(pelnionaFunkcja));
            if(czlonek != null && funkcja != null) 
            {
                czlonek.PelnionaFunkcja = funkcja;
            }
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcjaFromUser(string imieCzlonka, string nazwiskoCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            if(czlonek != null)
            {
                czlonek.PelnionaFunkcja = null; //It can be null because IdPelnionejFunkcji in Czlonek is nullable
            }
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

        public void AddEventToTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            if(wydarzenie!=null)
            {
                zespol.Wydarzenia.Add(wydarzenie);
            }
            unitOfWork.Save();
        }

        public void RemoveEventFromTeam(string nazwaZespolu, string nazwaWydarzenia)
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

        
    }
}
