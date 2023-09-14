using AutoMapper;
using BLL.Models;
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
        private readonly IMapper mapper;
        public PrzewodniczacyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcja)
        {
           
/*            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            var funkcja = unitOfWork.PelnioneFunkcje.GetPelnioneFunkcje().FirstOrDefault(pelnionaFunkcja => pelnionaFunkcja.Nazwa.Equals(pelnionaFunkcja));
            if(czlonek != null && funkcja != null) 
            {
                czlonek.PelnionaFunkcja = funkcja;
            }*/
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcja)
        {
/*            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Imie.Equals(imieCzlonka) && czlonek.Nazwisko.Equals(nazwiskoCzlonka));
            if(czlonek != null)
            {
                czlonek.PelnionaFunkcja = null; //It can be null because IdPelnionejFunkcji in Czlonek is nullable
            }*/
            unitOfWork.Save();
        }

        public void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
/*            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonkowie().FirstOrDefault(czlonek => czlonek.Nazwisko.Equals(nazwiskoCzlonka) && czlonek.Imie.Equals(imieCzlonka));
            var zespol = unitOfWork.Zespoly.GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));*/
/*            if (czlonek != null && zespol == null)
            {
                czlonek.Sprzety.Add(sprzet);
            }
            else
            {
                zespol.Sprzety.Add(sprzet);
            }*/
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
/*            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
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
            unitOfWork.Save();*/
        }


        public void AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            if (czlonekDto == null)
            {
                throw new Exception();
            }
            var czlonek = mapper.Map<Czlonek>(czlonekDto);
            unitOfWork.Zespoly.InsertCzlonek(idZespolu, czlonek);
            unitOfWork.Save();
        }

        public void RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            if (czlonekDto == null)
            {
                throw new Exception();
            }
            var czlonek = mapper.Map<Czlonek>(czlonekDto);
            unitOfWork.Zespoly.DeleteCzlonek(idZespolu, czlonek);
            unitOfWork.Save();
        }

        public void AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);//GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
            var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
            unitOfWork.Zespoly.InsertWydarzenie(idZespolu, wydarzenie);
            unitOfWork.Save();
        }

        public void RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);

            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
            var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
            unitOfWork.Zespoly.DeleteWydarzenie(idZespolu, wydarzenie);
            unitOfWork.Save();
        }

        public void AddProjektToTeam(int idZespolu, ProjektDTO projektDto)
        {
            if (projektDto == null)
            {
                throw new Exception();
            }
            var projekt = mapper.Map<Projekt>(projektDto);
            unitOfWork.Zespoly.InsertProjekt(idZespolu, projekt);
            unitOfWork.Save();
        }

        public void RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDto)
        {
            if (projektDto == null)
            {
                throw new Exception();
            }
            var projekt = mapper.Map<Projekt>(projektDto);
            unitOfWork.Zespoly.DeleteProjekt(idZespolu, projekt);
            unitOfWork.Save();
        }

        public void AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
/*            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            projekt.Zespol = zespol;*/
            unitOfWork.Save();
        }

        public void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
/*            var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
            projekt.Zespol = null;*/
            unitOfWork.Save();
        }

        public void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
/*            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            wydarzenie.Zespol = zespol;*/
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
/*            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenia().FirstOrDefault(wydarzenie => wydarzenie.Nazwa.Equals(nazwaWydarzenia));
            wydarzenie.Zespol = null;*/
            unitOfWork.Save();
        }

        
    }
}
