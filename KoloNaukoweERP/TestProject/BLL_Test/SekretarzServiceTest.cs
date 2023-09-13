﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Services.Sekretarz;
using DAL.Entities;
using DAL;
using TestProject.BLL_Test.FakeRopsitories;
using DAL.Repositories.WydarzenieR;
using DAL.Repositories.ZespolR;
using Moq;
using DAL.Repositories.SprzetR;
using DAL.Repositories.ProjektR;
using DAL.Repositories.PelnionaFunkcjaR;
using DAL.Repositories.CzlonekR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using BLL.Models;
using AutoMapper;

namespace TestProject.BLL_Test
{
    public class SekretarzServiceTest
    {
        [Fact]
        public void TestAddCzlonekMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var czlonekDto = mockMapper.Object.Map<CzlonekDTO>(czlonek);
            sekretarz.AddCzlonek(czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Czlonkowie.InsertCzlonek(It.IsAny<Czlonek>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]
        public void TestRemoveCzlonekMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var czlonekDto = mockMapper.Object.Map<CzlonekDTO>(czlonek);

            sekretarz.AddCzlonek(czlonekDto);
            sekretarz.RemoveCzlonek(czlonekDto.IdCzlonka);

            unitOfWorkMock.Verify(repo => repo.Czlonkowie.DeleteCzlonek(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddCzlonekToTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol));

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));
            unitOfWorkMock.Setup(u => u.Zespoly.InsertCzlonek(zespol.IdZespolu, It.IsAny<Czlonek>()));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var czlonekDto = mockMapper.Object.Map<CzlonekDTO>(czlonek);

            sekretarz.AddCzlonekToTeam(zespol.IdZespolu, czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertCzlonek(zespol.IdZespolu, It.IsAny<Czlonek>()), Times.Once);
        }

        [Fact]
        public void TestRemoveCzlonekFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var czlonek = new Czlonek();
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));
            unitOfWorkMock.Setup(u => u.Zespoly.InsertCzlonek(zespol.IdZespolu, czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var czlonekDto = mockMapper.Object.Map<CzlonekDTO>(czlonek);

            sekretarz.AddCzlonekToTeam(zespol.IdZespolu, czlonekDto);
            sekretarz.RemoveCzlonekFromTeam(zespol.IdZespolu, czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteCzlonek(zespol.IdZespolu, czlonek), Times.Once());
        }

        [Fact]
        public void TestAddZespolMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var zespolDto = mockMapper.Object.Map<ZespolDTO>(zespol);

            sekretarz.AddZespol(zespolDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertZespol(It.IsAny<Zespol>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveZespolMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var zespolDto = mockMapper.Object.Map<ZespolDTO>(zespol);

            sekretarz.AddZespol(zespolDto);
            sekretarz.RemoveZespol(zespolDto.IdZespolu);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteZespol(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }




        // AddWypozyczenie             do zweryfikowania czy chcemy?
        // RemoveWypozyczenie          do zweryfikowania czy chcemy?






        [Fact]
        public void TestAddWydarzenieMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespoly()).Returns(new List<Zespol> { zespol });

            var wydarzenie = new Wydarzenie();
            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            var wydarzenieDto = mockMapper.Object.Map<WydarzenieDTO>(wydarzenie);

            sekretarz.AddWydarzenie(wydarzenieDto);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.InsertWydarzenie(It.IsAny<Wydarzenie>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
            
        }

        [Fact]
        public void TestAddWydarzenie()
        {
            var wydarzenieRepo = new WydarzenieRepoFake();
            var zespolRepo = new ZespolRepoFake();
            var sprzetRepo = new SprzetRepoFake();
            var projektRepo = new ProjektRepoFake();
            var czlonekRepo = new CzlonekRepoFake();
            var pelnionaFunkcjaRepo = new PelnionaFunkcjaRepoFake();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "zespol1" };
            zespolRepo.InsertZespol(zespol);

            var unitOfWork = new UnitOfWork(czlonekRepo, pelnionaFunkcjaRepo, projektRepo, sprzetRepo, wydarzenieRepo, zespolRepo);
            var sekretarz = new SekretarzeServices(unitOfWork);
            var wydarzenie = new Wydarzenie();
            sekretarz.AddWydarzenie(wydarzenie);

            Assert.Equal(1, wydarzenieRepo.GetWydarzenia().Count());
        }

        [Fact]
        public void TestRemoveWydarzenie()
        {
            var wydarzenieRepo = new WydarzenieRepoFake();
            var zespolRepo = new ZespolRepoFake();
            var sprzetRepo = new SprzetRepoFake();
            var projektRepo = new ProjektRepoFake();
            var czlonekRepo = new CzlonekRepoFake();
            var pelnionaFunkcjaRepo = new PelnionaFunkcjaRepoFake();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "zespol1" };
            zespolRepo.InsertZespol(zespol);

            var unitOfWork = new UnitOfWork(czlonekRepo, pelnionaFunkcjaRepo, projektRepo, sprzetRepo, wydarzenieRepo, zespolRepo);
            var sekretarz = new SekretarzeServices(unitOfWork);

            var wydarzenie = new Wydarzenie();
            sekretarz.AddWydarzenie(wydarzenie);

            sekretarz.RemoveWydarzenie("Test");
            Assert.Equal(0, wydarzenieRepo.GetWydarzenia().Count());
        }

        [Fact]
        public void TestAddWydarzenieToTeam()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var wydarzenie = new Wydarzenie();

            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));
            unitOfWorkMock.Setup(u => u.Zespoly.InsertWydarzenie(zespol.IdZespolu, wydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddWydarzenie(wydarzenie);

            var team = new Zespol();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(team));

            sekretarz.AddWydarzenieToTeam(1, wydarzenie);


            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertWydarzenie(1, It.IsAny<Wydarzenie>()), Times.Once());
        }

        [Fact]
        public void TestRemoveWydarzenieFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var wydarzenie = new Wydarzenie();

            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));
            unitOfWorkMock.Setup(u => u.Zespoly.InsertWydarzenie(zespol.IdZespolu, wydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddWydarzenie(wydarzenie);

            sekretarz.AddWydarzenieToTeam(1, wydarzenie);
            sekretarz.RemoveWydarzenieFromTeam(zespol.IdZespolu, wydarzenie);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteWydarzenie(zespol.IdZespolu,wydarzenie), Times.Once());
            //unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }




        // AddProjektToTeam
        public void TestAddProjektToTeamMoq()
        {
            var  unitOfWorkMock = new Mock<IUnitOfWork>();
            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u=>u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            //czy to nie to samo - domniemana nadmiarowość
        }
        // RemoveProjektFromTeam
        // AddZespolToProject
        // RemoveZespolFromProject



        [Fact]
        public void TestAddZespolToEventMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var wydarzenie = new Wydarzenie() { IdWydarzenia = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia)).Returns(wydarzenie);

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddZespolToEvent(wydarzenie.IdWydarzenia, zespol);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.InsertZespol(wydarzenie.IdWydarzenia, It.IsAny<Zespol>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemoveZespolFromEventMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var wydarzenie = new Wydarzenie() { IdWydarzenia = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia)).Returns(wydarzenie);

            var zespol = new Zespol();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(It.IsAny<Zespol>()));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddZespolToEvent(wydarzenie.IdWydarzenia, zespol);
            sekretarz.RemoveZespolFromEvent(wydarzenie.IdWydarzenia, zespol);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.DeleteZespol(wydarzenie.IdWydarzenia, zespol), Times.Once());
        }



        // AddPelnionaFunkcja
        // RemovePelnionaFunkcja
        // AddPelnionaFunkcjaToUser
        // RemovePelnionaFunkcjaFromUser





        [Fact]
        public void TestAddSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var sprzet = new Sprzet() { Nazwa = "Test", Opis = "Test", CzyDostepny = true };
            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddSprzet(sprzet);
            unitOfWorkMock.Verify(repo => repo.Sprzety.InsertSprzet(It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemoveSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var sprzet = new Sprzet() { Nazwa = "Test", Opis = "Test", CzyDostepny = true };
            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddSprzet(sprzet);

            sekretarz.RemoveSprzet(sprzet.IdSprzetu);
            unitOfWorkMock.Verify(repo => repo.Sprzety.DeleteSprzet(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddSprzetToTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespoly()).Returns(new List<Zespol> { zespol });

            var sprzet = new Sprzet() { IdSprzetu = 1, Nazwa = "Test", Opis = "Test", CzyDostepny = true };

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddSprzetToTeam(zespol.IdZespolu, sprzet);

            unitOfWorkMock.Verify(repo => repo.Zespoly.AddSprzet(zespol.IdZespolu, It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemoveSprzetFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));
            unitOfWorkMock.Setup(u => u.Zespoly.AddSprzet(zespol.IdZespolu, sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddSprzet(sprzet);

            var zespol2 = new Zespol();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol2));

            sekretarz.AddSprzetToTeam(zespol.IdZespolu, sprzet);
            sekretarz.RemoveSprzetFromTeam(zespol.IdZespolu, sprzet);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteSprzet(zespol.IdZespolu, sprzet), Times.Once());
        }

        [Fact]
        public void TestAddProjektMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt() { Nazwa = "Test", Opis = "Test", TerminRealizacji = DateTime.Now, IdZespolu = zespol.IdZespolu };
            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddProjekt(projekt);
            unitOfWorkMock.Verify(repo=>repo.Projekty.InsertProjekt(It.IsAny<Projekt>()),Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveProjektMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt() { Nazwa = "Test", Opis = "Test", TerminRealizacji = DateTime.Now };
            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddProjekt(projekt);
            sekretarz.RemoveProjekt(projekt.IdProjektu);
            unitOfWorkMock.Verify(repo => repo.Projekty.DeleteProjekt(It.IsAny<int>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        
        [Fact]
        public void TestGetEventMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var wydarzenie = new Wydarzenie() { IdWydarzenia = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia)).Returns(wydarzenie);

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.GetEvent(wydarzenie.IdWydarzenia);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]
        public void TestGetEventsMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var wydarzenia = new List<Wydarzenie>() { };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenia()).Returns(wydarzenia);

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.GetEvents();

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.GetWydarzenia(), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }



        // GetTeam
        // GetTeams


        public void Dispose()
        {
            //do nothing
        }

        public void Save()
        {
            //do nothing
        }
    }
}