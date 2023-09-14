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
using Microsoft.Identity.Client;

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
            if(idCzlonka==null)
            {
                throw new Exception();
            }
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

        public void RemoveZespol(int? idZespolu)
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

        public void RemoveWydarzenie(int idWydarzenia)
        {
            if (idWydarzenia==null)
            {
                throw new Exception();
            }
            unitOfWork.Wydarzenia.DeleteWydarzenie(idWydarzenia);
            unitOfWork.Save();
        }

        public void AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
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

        public void RemovePelnionaFunkcja(int? idPelnionejFunkcji)
        {
            if(idPelnionejFunkcji==null)
            {
                throw new Exception();
            }
            unitOfWork.PelnioneFunkcje.DeletePelnionaFunkcja(idPelnionejFunkcji);
            unitOfWork.Save();
        }

        public void AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            if(pelnionaFunkcjaDto==null)
            {
                throw new Exception();
            }
            var pelnionaFunkcja = mapper.Map<PelnionaFunkcja>(pelnionaFunkcjaDto);
            unitOfWork.Czlonkowie.InsertPelnionaFunkcja(idCzlonka, pelnionaFunkcja);
            unitOfWork.Save();
        }

        public void RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            if (pelnionaFunkcjaDto == null)
            {
                throw new Exception();
            }
            var pelnionaFunkcja = mapper.Map<PelnionaFunkcja>(pelnionaFunkcjaDto);
            unitOfWork.Czlonkowie.DeletePelnionaFunkcja(idCzlonka, pelnionaFunkcja);
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

        public void RemoveSprzet(int? idSprzetu)
        {
            if(idSprzetu==null)
            {
                throw new Exception();
            }
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
            if(idProjektu==null)
            {
                throw new Exception();
            }
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
            if(zespol==null)
            {
                throw new Exception();
            }
            return mapper.Map<ZespolDTO>(zespol);
        }

        public List<ZespolDTO> GetTeams()
        {
            var list = new List<Zespol>();
            list = (List<Zespol>)unitOfWork.Zespoly.GetZespoly();
            if(list==null)
            {
                throw new Exception();
            }
            return mapper.Map<List<ZespolDTO>>(list);
        }
    }
}
