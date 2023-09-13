@ -1,28 + 1,32 @@
﻿using DAL;
﻿using AutoMapper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace BLL.Services.Sekretarz
{
    public class SekretarzeServices : ISekretarzServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SekretarzeServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddCzlonek(Czlonek czlonek)
        public void AddCzlonek(CzlonekDTO czlonekDto)
        {
            if (czlonek == null)
                if (czlonekDto == null)
                {
                    throw new Exception();
                }
            var czlonek = mapper.Map<Czlonek>(czlonekDto);
            unitOfWork.Czlonkowie.InsertCzlonek(czlonek);
            unitOfWork.Save();
        }
@ -34,39 +38,45 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }

    public void AddCzlonekToTeam(int idZespolu, Czlonek czlonek)
        public void AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto)
    {
        if (czlonek == null)
            if (czlonekDto == null)
            {
                throw new Exception();
            }
        var czlonek = mapper.Map<Czlonek>(czlonekDto);
        unitOfWork.Zespoly.InsertCzlonek(idZespolu, czlonek);
        unitOfWork.Save();
    }

    public void RemoveCzlonekFromTeam(int idZespolu, Czlonek czlonek)
        public void RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto)
    {
        if (czlonek == null)
            if (czlonekDto == null)
            {
                throw new Exception();
            }
        var czlonek = mapper.Map<Czlonek>(czlonekDto);
        unitOfWork.Zespoly.DeleteCzlonek(idZespolu, czlonek);
        unitOfWork.Save();
    }

    public void AddZespol(Zespol zespol)
        public void AddZespol(ZespolDTO zespolDto)
    {
        if (zespol == null)
            if (zespolDto == null)
            {
                throw new Exception();
            }
        var zespol = mapper.Map<Zespol>(zespolDto);
        unitOfWork.Zespoly.InsertZespol(zespol);
        unitOfWork.Save();
    }

    public void RemoveZespol(int idZespolu) //zostawiac po id, tylko warunek ?null
        public void RemoveZespol(int idZespolu)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
        if (idZespolu == null)
        {
            throw new NotImplementedException();
        }
        unitOfWork.Zespoly.DeleteZespol(idZespolu);
        unitOfWork.Save();
    }
@ -103,14 +113,14 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }*/

        public void AddWydarzenie(Wydarzenie wydarzenie)
        public void AddWydarzenie(WydarzenieDTO wydarzenieDto)
    {
        if (wydarzenie == null)
            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
        var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
        unitOfWork.Wydarzenia.InsertWydarzenie(wydarzenie);

        unitOfWork.Save();
    }

@ -125,35 +135,35 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }

    public void AddWydarzenieToTeam(int idZespolu, Wydarzenie wydarzenie)
        public void AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);//GetZespoly().FirstOrDefault(zespol => zespol.Nazwa.Equals(nazwaZespolu));
        if (wydarzenie == null)
            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
        var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
        unitOfWork.Zespoly.InsertWydarzenie(idZespolu, wydarzenie);
        unitOfWork.Save();
    }

    public void RemoveWydarzenieFromTeam(int idZespolu, Wydarzenie wydarzenie)
        public void RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
        if (wydarzenie == null)
            if (wydarzenieDto == null)
            {
                throw new Exception();
            }
        var wydarzenie = mapper.Map<Wydarzenie>(wydarzenieDto);
        unitOfWork.Zespoly.DeleteWydarzenie(idZespolu, wydarzenie);
        unitOfWork.Save();
    }

    public void AddProjektToTeam(int idZespolu, Projekt projekt)
        public void AddProjektToTeam(int idZespolu, ProjektDTO projektDto)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
        if (projekt == null)
            if (projektDto == null)
            {
                throw new Exception();
            }
        var projekt = mapper.Map<Projekt>(projektDto);
        unitOfWork.Zespoly.InsertProjekt(idZespolu, projekt);
        unitOfWork.Save();
    }
@ -170,13 +180,15 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }

    public void AddZespolToProject(Zespol zespol, string nazwaProjektu)
        //TODO: To fix
        public void AddZespolToProject(ZespolDTO zespolDto, string nazwaProjektu)
    {
        var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
        projekt.Zespol = zespol;
        //projekt.Zespol = zespol;
        unitOfWork.Save();
    }

    //TODO: To fix
    public void RemoveZespolFromProject(Zespol zespol, string nazwaProjektu)
    {
        var projekt = unitOfWork.Projekty.GetProjekty().FirstOrDefault(projekt => projekt.Nazwa.Equals(nazwaProjektu));
@ -184,34 + 196,35 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }

    public void AddZespolToEvent(int idWydarzenia, Zespol zespol)
        public void AddZespolToEvent(int idWydarzenia, ZespolDTO zespolDto)
    {
        var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
        if (zespol == null)
            if (zespolDto == null)
            {
                throw new Exception();
            }
        var zespol = mapper.Map<Zespol>(zespolDto);
        unitOfWork.Wydarzenia.InsertZespol(idWydarzenia, zespol);
        unitOfWork.Save();
    }

    public void RemoveZespolFromEvent(int idWydarzenia, Zespol zespol)
        public void RemoveZespolFromEvent(int idWydarzenia, ZespolDTO zespolDto)
    {
        var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
        if (zespol == null)
            if (zespolDto == null)
            {
                throw new Exception();
            }
        var zespol = mapper.Map<Zespol>(zespolDto);
        unitOfWork.Wydarzenia.DeleteZespol(idWydarzenia, zespol);
        unitOfWork.Save();
    }

    public void AddPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        public void AddPelnionaFunkcja(PelnionaFunkcjaDTO pelnionaFunkcjaDto)
    {
        if (pelnionaFunkcja == null)
            if (pelnionaFunkcjaDto == null)
            {
                throw new Exception();
            }
        var pelnionaFunkcja = mapper.Map<PelnionaFunkcja>(pelnionaFunkcjaDto);
        unitOfWork.PelnioneFunkcje.InsertPelnionaFunkcja(pelnionaFunkcja);
        unitOfWork.Save();
    }
@ -247,14 +260,13 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }



    public void AddSprzet(Sprzet sprzet)
        public void AddSprzet(SprzetDTO sprzetDto)
    {
        if (sprzet == null)
            if (sprzetDto == null)
            {
                throw new Exception();
            }
        var sprzet = mapper.Map<Sprzet>(sprzetDto);
        unitOfWork.Sprzety.InsertSprzet(sprzet);
        unitOfWork.Save();
    }
@ -267,39 +279,34 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Save();
    }

    public void AddSprzetToTeam(int idZespolu, Sprzet sprzet)
        public void AddSprzetToTeam(int idZespolu, SprzetDTO sprzetDto)
    {
        if (sprzet == null)
            if (sprzetDto == null)
            {
                throw new Exception();
            }
        var sprzet = mapper.Map<Sprzet>(sprzetDto);
        unitOfWork.Zespoly.AddSprzet(idZespolu, sprzet);
        unitOfWork.Save();
    }
    public void RemoveSprzetFromTeam(int idZespolu, Sprzet sprzet)
        public void RemoveSprzetFromTeam(int idZespolu, SprzetDTO sprzetDto)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
        if (sprzet == null)
            if (sprzetDto == null)
            {
                throw new Exception();
            }
        var sprzet = mapper.Map<Sprzet>(sprzetDto);
        unitOfWork.Zespoly.DeleteSprzet(idZespolu, sprzet);
        //unitOfWork.Zespoly.DeleteSprzet(idZespolu,sprzet); 
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
        if (projekt == null)
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
@ -309,35 + 316,34 @@ namespace BLL.Services.Sekretarz
            unitOfWork.Projekty.DeleteProjekt(idProjektu);
            unitOfWork.Save();
        }
    public Wydarzenie GetEvent(int idWydarzenia)
        public WydarzenieDTO GetEvent(int idWydarzenia)
    {
        var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
        var wydarzenieDto = mapper.Map<WydarzenieDTO>(wydarzenie);
        unitOfWork.Save();
        return wydarzenie;
        return wydarzenieDto;
    }
    public IEnumerable<Wydarzenie> GetEvents()
        public IEnumerable<WydarzenieDTO> GetEvents()
    {
        var wydarzenia = unitOfWork.Wydarzenia.GetWydarzenia();

        if (wydarzenia == null)
        {
            throw new Exception();
        }

        unitOfWork.Save();
        return wydarzenia;
        return mapper.Map<IEnumerable<WydarzenieDTO>>(wydarzenia);
    }

    public Zespol GetTeam(int idZespolu)
        public ZespolDTO GetTeam(int idZespolu)
    {
        var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
        return zespol;
        return mapper.Map<ZespolDTO>(zespol);
    }
    public List<Zespol> GetTeams()
        public List<ZespolDTO> GetTeams()
    {
        var list = new List<Zespol>();
        list = (List<Zespol>)unitOfWork.Zespoly.GetZespoly();
        return list;
        return mapper.Map<List<ZespolDTO>>(list);
    }

}
