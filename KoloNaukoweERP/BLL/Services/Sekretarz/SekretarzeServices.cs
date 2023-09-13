using DAL;
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

        public void AddCzlonek(Czlonek czlonek)
        {
            if(czlonek == null) 
            {
                throw new Exception();
            }
            unitOfWork.Czlonkowie.InsertCzlonek(czlonek);
            unitOfWork.Save();
        }

        public void RemoveCzlonek(int idCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            unitOfWork.Czlonkowie.DeleteCzlonek(idCzlonka);
            unitOfWork.Save();
        }

        public void AddCzlonekToTeam(int idZespolu, Czlonek czlonek)
        {
            if (czlonek == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.InsertCzlonek(idZespolu, czlonek);
            unitOfWork.Save();
        }

        public void RemoveCzlonekFromTeam(int idZespolu, Czlonek czlonek)
        {
            if (czlonek == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.DeleteCzlonek(czlonek.IdCzlonka);
            unitOfWork.Save();
        }

        public void AddZespol(Zespol zespol)
        {
            if (zespol == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.InsertZespol(zespol);
            unitOfWork.Save();
        }

        public void RemoveZespol(int idZespolu) //zostawiac po id, tylko warunek ?null
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            unitOfWork.Zespoly.DeleteZespol(idZespolu);
            unitOfWork.Save();
        }

        /*public void AddWypozyczenie(string nazwaSprzetu, string nazwiskoCzlonka, string imieCzlonka, string nazwaZespolu)
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
        }*/

        public void AddWydarzenie(Wydarzenie wydarzenie)
        {
            if(wydarzenie==null)
            {
                throw new Exception();
            }
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

        public void AddWydarzenieToTeam(int idZespolu, Wydarzenie wydarzenie)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);//GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            if (wydarzenie == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.InsertWydarzenie(idZespolu, wydarzenie);
            unitOfWork.Save();
        }

        public void RemoveWydarzenieFromTeam(int idZespolu, Wydarzenie wydarzenie)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            if (wydarzenie == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.DeleteWydarzenie(wydarzenie.IdWydarzenia);
            unitOfWork.Save();
        }

        public void AddProjektToTeam(int idZespolu, Projekt projekt)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            if (projekt == null)
            {
                throw new Exception();    
            }
            unitOfWork.Zespoly.InsertProjekt(idZespolu,projekt);
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

        public void AddZespolToEvent(int idWydarzenia, Zespol zespol)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            if (zespol == null)
            {
                throw new Exception();
            }
            unitOfWork.Wydarzenia.InsertZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(int idWydarzenia, Zespol zespol)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            if(zespol==null)
            {
                throw new Exception();
            }
            unitOfWork.Wydarzenia.DeleteZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }

        public void AddPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            if(pelnionaFunkcja == null)
            {
                throw new Exception();
            }
            unitOfWork.PelnioneFunkcje.InsertPelnionaFunkcja(pelnionaFunkcja);
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcja(string nazwaPelnionejFunkcji)
        {
            var funkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(funkcja => funkcja.Nazwa.Equals(nazwaPelnionejFunkcji));
            var funkcjaId = funkcja.IdPelnionejFunkcji;
            if (funkcja != null)
            {
                unitOfWork.PelnioneFunkcje.DeletePelnionaFunkcja(funkcjaId);
            }
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
                czlonek.PelnionaFunkcja = null;
            }
            unitOfWork.Save();
        }

        
        
        public void AddSprzet(Sprzet sprzet)
        {
            if(sprzet == null)
            {
                throw new Exception();
            }
            unitOfWork.Sprzety.InsertSprzet(sprzet);
            unitOfWork.Save();
        }

        public void RemoveSprzet(int idSprzetu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzetById(idSprzetu);

            unitOfWork.Sprzety.DeleteSprzet(idSprzetu);
            unitOfWork.Save();
        }

        public void AddSprzetToTeam(int idZespolu, Sprzet sprzet)
        {
            if (sprzet == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.AddSprzet(idZespolu, sprzet);
            unitOfWork.Save();
        }
        public void RemoveSprzetFromTeam(int idZespolu, Sprzet sprzet)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            if (sprzet == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.DeleteSprzet(sprzet.IdSprzetu);
            unitOfWork.Save();
        }
        
        public void AddProjekt(Projekt projekt)
        {
            /*var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            Projekt projekt = new Projekt();
            projekt.Nazwa = nazwaProjektu;
            projekt.Zespol = zespol;
            projekt.TerminRealizacji = terminRealizacji;
            projekt.Opis = opisWydarzenia;*/
            if(projekt == null)
            {
                throw new Exception();
            }
            unitOfWork.Projekty.InsertProjekt(projekt);
            unitOfWork.Save();
        }
        public void RemoveProjekt(int idProjektu)
        {
            var projekt = unitOfWork.Projekty.GetProjektById(idProjektu);
            unitOfWork.Projekty.DeleteProjekt(idProjektu);
            unitOfWork.Save();
        }
        public Wydarzenie GetEvent(int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            unitOfWork.Save();
            return wydarzenie;
        }
        public IEnumerable<Wydarzenie> GetEvents()
        {
            var wydarzenia = unitOfWork.Wydarzenia.GetWydarzenia();
 
            if(wydarzenia==null)
            {
                throw new Exception();
            }

            unitOfWork.Save();
            return wydarzenia;
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
