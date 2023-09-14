﻿using DAL;
using AutoMapper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services.Sekretarz
{
    public class SekretarzeServices : ISekretarzServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SekretarzeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AddCzlonek(CzlonekDTO czlonekDto)
        {
            if (czlonekDto == null)
            {
                throw new Exception();
            }
            var czlonek = mapper.Map<Czlonek>(czlonekDto);
            unitOfWork.Czlonkowie.InsertCzlonek(czlonek);
            unitOfWork.Save();
        }
        public void RemoveCzlonek(int idCzlonka)
        {
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            unitOfWork.Czlonkowie.DeleteCzlonek(idCzlonka);
            unitOfWork.Save();
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

        public void AddZespol(ZespolDTO zespolDto)
        {
            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Zespoly.InsertZespol(zespol);
            unitOfWork.Save();
        }

        public void RemoveZespol(int idZespolu)
        {
            if (idZespolu == null)
            {
                throw new Exception();
            }
            unitOfWork.Zespoly.DeleteZespol(idZespolu);
            unitOfWork.Save();

        }

        public void AddWydarzenie(WydarzenieDTO wydarzenieDto)
        {
            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
            var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
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
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            if (projektDto == null)
            {
                throw new Exception();
            }
            var projekt = mapper.Map<Projekt>(projektDto);
            unitOfWork.Zespoly.InsertProjekt(idZespolu, projekt);
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

        public void AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
            if(zespolDto==null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Projekty.InsertZespol(idProjektu, zespol);
            unitOfWork.Save();
        }

        public void RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Projekty.DeleteZespol(idProjektu, zespol);
            unitOfWork.Save();
        }

        public void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Wydarzenia.InsertZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);

            if (zespolDto == null)
            {
                throw new Exception();
            }
            var zespol = mapper.Map<Zespol>(zespolDto);
            unitOfWork.Wydarzenia.DeleteZespol(idWydarzenia, zespol);
            unitOfWork.Save();
        }

        public void AddPelnionaFunkcja(PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {

            if (pelnionaFunkcjaDto == null)
            {
                throw new Exception();
            }
            var pelnionaFunkcja = mapper.Map<PelnionaFunkcja>(pelnionaFunkcjaDto);
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

        public void AddSprzet(SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Sprzety.InsertSprzet(sprzet);
            unitOfWork.Save();
        }

        public void RemoveSprzet(int idSprzetu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzetById(idSprzetu);

            unitOfWork.Sprzety.DeleteSprzet(idSprzetu);
            unitOfWork.Save();
        }

        public void AddSprzetToTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Zespoly.AddSprzet(idZespolu, sprzet);
            unitOfWork.Save();
        }

        public void RemoveSprzetFromTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Zespoly.DeleteSprzet(idZespolu, sprzet);
            unitOfWork.Save();
        }


        public void AddProjekt(ProjektDTO projektDto)
        {
            if (projektDto == null)
            {
                throw new Exception();
            }
            var projekt = mapper.Map<Projekt>(projektDto);
            unitOfWork.Projekty.InsertProjekt(projekt);
            unitOfWork.Save();
        }

        public void RemoveProjekt(int idProjektu)
        {
            var projekt = unitOfWork.Projekty.GetProjektById(idProjektu);
            unitOfWork.Projekty.DeleteProjekt(idProjektu);
            unitOfWork.Save();
        }

        public WydarzenieDTO GetEvent(int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            var wydarzenieDto = mapper.Map<WydarzenieDTO>(wydarzenie);
            unitOfWork.Save();
            return wydarzenieDto;
        }

        public IEnumerable<WydarzenieDTO> GetEvents()
        {
            var wydarzenia = unitOfWork.Wydarzenia.GetWydarzenia();

            if (wydarzenia == null)
            {
                throw new Exception();
            }

            unitOfWork.Save();
            return mapper.Map<IEnumerable<WydarzenieDTO>>(wydarzenia);
        }

        public ZespolDTO GetTeam(int idZespolu)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            return mapper.Map<ZespolDTO>(zespol);
        }
        public List<ZespolDTO> GetTeams()
        {
            var list = new List<Zespol>();
            list = (List<Zespol>)unitOfWork.Zespoly.GetZespoly();

            return mapper.Map<List<ZespolDTO>>(list);
        }
    }
}
