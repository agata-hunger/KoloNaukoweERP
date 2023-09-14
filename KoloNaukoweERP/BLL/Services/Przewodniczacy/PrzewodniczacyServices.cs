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

        public void AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            if (pelnionaFunkcjaDto == null)
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

        public void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.InsertWypozyczenie(idCzlonka, sprzet);
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            if (sprzetDto == null)
            {
                throw new Exception();
            }
            var sprzet = mapper.Map<Sprzet>(sprzetDto);
            unitOfWork.Czlonkowie.DeleteWypozyczenie(idCzlonka, sprzet);
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
            if (zespolDto == null)
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


    }
}
