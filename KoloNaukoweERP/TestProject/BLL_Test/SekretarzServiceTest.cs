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

            mockMapper.Setup(x => x.Map<Czlonek>(It.IsAny<CzlonekDTO>()))
                .Returns((CzlonekDTO src) => new Czlonek { });

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var czlonekDto = new CzlonekDTO() { };

            sekretarz.AddCzlonek(czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Czlonkowie.InsertCzlonek(It.IsAny<Czlonek>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]
        public void TestRemoveCzlonekMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Czlonek>(It.IsAny<CzlonekDTO>()))
                .Returns((CzlonekDTO src) => new Czlonek { });

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertCzlonek(czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var czlonekDto = new CzlonekDTO() { };

            sekretarz.RemoveCzlonek(czlonekDto.IdCzlonka);

            unitOfWorkMock.Verify(repo => repo.Czlonkowie.DeleteCzlonek(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddCzlonekToTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Czlonek>(It.IsAny<CzlonekDTO>()))
                .Returns((CzlonekDTO src) => new Czlonek { });

            var zespol = new Zespol() { };

            var czlonek = new Czlonek() { };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertCzlonek(zespol.IdZespolu, It.IsAny<Czlonek>()));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var czlonekDto = new CzlonekDTO();

            sekretarz.AddCzlonekToTeam(zespol.IdZespolu, czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertCzlonek(zespol.IdZespolu, It.IsAny<Czlonek>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]
        public void TestRemoveCzlonekFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Czlonek>(It.IsAny<CzlonekDTO>()))
                .Returns((CzlonekDTO src) => new Czlonek { });

            var zespol = new Zespol() { };

            var czlonek = new Czlonek();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertCzlonek(zespol.IdZespolu, czlonek));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var czlonekDto = new CzlonekDTO();

            sekretarz.RemoveCzlonekFromTeam(zespol.IdZespolu, czlonekDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteCzlonek(zespol.IdZespolu, It.IsAny<Czlonek>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddZespolMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Zespol>(It.IsAny<ZespolDTO>()))
                .Returns((ZespolDTO src) => new Zespol { });

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var zespolDto = new ZespolDTO() { };

            sekretarz.AddZespol(zespolDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertZespol(It.IsAny<Zespol>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveZespolMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Zespol>(It.IsAny<ZespolDTO>()))
                .Returns((ZespolDTO src) => new Zespol { });

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(zespol));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var zespolDto = new ZespolDTO() { };    

            sekretarz.RemoveZespol(zespolDto.IdZespolu);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteZespol(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddWypozyczenieMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var czlonek = new Czlonek();
            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertWypozyczenie(czlonek.IdCzlonka, It.IsAny<Sprzet>()));
            
            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object,mockMapper.Object);
            var sprzetDto = new SprzetDTO();

            sekretarz.AddWypozyczenie(czlonek.IdCzlonka, sprzetDto);

            unitOfWorkMock.Verify(repo=>repo.Czlonkowie.InsertWypozyczenie(czlonek.IdCzlonka,It.IsAny<Sprzet>()),Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]
        public void TestRemoveWyporzyczenieMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var czlonek = new Czlonek();
            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Czlonkowie.InsertWypozyczenie(czlonek.IdCzlonka, sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var sprzetDto = new SprzetDTO();

            sekretarz.RemoveWypozyczenie(czlonek.IdCzlonka, sprzetDto);

            unitOfWorkMock.Verify(repo => repo.Czlonkowie.DeleteWypozyczenie(czlonek.IdCzlonka, It.IsAny<Sprzet>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }




        [Fact]
        public void TestAddWydarzenieMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var wydarzenie = new Wydarzenie();
            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO(){ };

            sekretarz.AddWydarzenie(wydarzenieDto);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.InsertWydarzenie(It.IsAny<Wydarzenie>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestAddWydarzenie()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var wydarzenieRepo = new WydarzenieRepoFake();
            var zespolRepo = new ZespolRepoFake();
            var sprzetRepo = new SprzetRepoFake();
            var projektRepo = new ProjektRepoFake();
            var czlonekRepo = new CzlonekRepoFake();
            var pelnionaFunkcjaRepo = new PelnionaFunkcjaRepoFake();

            var unitOfWork = new UnitOfWork(czlonekRepo, pelnionaFunkcjaRepo, projektRepo, sprzetRepo, wydarzenieRepo, zespolRepo);
            var sekretarz = new SekretarzeServices(unitOfWork, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO() { };
            sekretarz.AddWydarzenie(wydarzenieDto);

            Assert.Equal(1, wydarzenieRepo.GetWydarzenia().Count());
        }

        [Fact]
        public void TestRemoveWydarzenie()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var wydarzenieRepo = new WydarzenieRepoFake();
            var zespolRepo = new ZespolRepoFake();
            var sprzetRepo = new SprzetRepoFake();
            var projektRepo = new ProjektRepoFake();
            var czlonekRepo = new CzlonekRepoFake();
            var pelnionaFunkcjaRepo = new PelnionaFunkcjaRepoFake();

            var unitOfWork = new UnitOfWork(czlonekRepo, pelnionaFunkcjaRepo, projektRepo, sprzetRepo, wydarzenieRepo, zespolRepo);
            var sekretarz = new SekretarzeServices(unitOfWork, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO() { };

            sekretarz.RemoveWydarzenie(wydarzenieDto.IdWydarzenia);

            Assert.Equal(0, wydarzenieRepo.GetWydarzenia().Count());
        }

        [Fact]
        public void TestAddWydarzenieToTeam()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var wydarzenie = new Wydarzenie() { };

            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));
            var zespolWydarzenie = new ZespolWydarzenie() { WydarzenieId = wydarzenie.IdWydarzenia, Wydarzenie = wydarzenie, ZespolId = zespol.IdZespolu, Zespol = zespol };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertWydarzenie(zespol.IdZespolu, zespolWydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO() { };

            sekretarz.AddWydarzenieToTeam(zespol.IdZespolu, wydarzenieDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertWydarzenie(zespol.IdZespolu, It.IsAny<ZespolWydarzenie>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveWydarzenieFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
               .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var zespol = new Zespol() { };

            var wydarzenie = new Wydarzenie();
            var zespolWydarzenie = new ZespolWydarzenie() { WydarzenieId = wydarzenie.IdWydarzenia, Wydarzenie = wydarzenie, ZespolId = zespol.IdZespolu, Zespol = zespol };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertWydarzenie(zespol.IdZespolu, zespolWydarzenie));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO();

            sekretarz.AddWydarzenieToTeam(1, wydarzenieDto);
            sekretarz.RemoveWydarzenieFromTeam(zespol.IdZespolu, wydarzenieDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteWydarzenie(zespol.IdZespolu, It.IsAny<ZespolWydarzenie>()), Times.Once());
        }

        [Fact]
        public void TestAddProjektToTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Projekt>(It.IsAny<ProjektDTO>()))
                .Returns((ProjektDTO src) => new Projekt { });

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt() { };

            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));
            var zespolProjekt = new ZespolProjekt() { ProjektId = projekt.IdProjektu, Projekt = projekt, ZespolId = zespol.IdZespolu, Zespol = zespol };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertProjekt(zespol.IdZespolu, zespolProjekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var projektDto = new ProjektDTO() { };

            sekretarz.AddProjektToTeam(zespol.IdZespolu, projektDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.InsertProjekt(zespol.IdZespolu, It.IsAny<ZespolProjekt>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveProjektFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Projekt>(It.IsAny<ProjektDTO>()))
                .Returns((ProjektDTO src) => new Projekt { });

            var zespol = new Zespol() { };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt();
            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));

            var zespolProjekt = new ZespolProjekt() { ProjektId = projekt.IdProjektu, Projekt = projekt, ZespolId = zespol.IdZespolu, Zespol = zespol };
            unitOfWorkMock.Setup(u => u.Zespoly.InsertProjekt(zespol.IdZespolu, zespolProjekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var projekttDto = new ProjektDTO() { };

            sekretarz.AddProjektToTeam(zespol.IdZespolu, projekttDto);
            sekretarz.RemoveProjektFromTeam(zespol.IdZespolu, projekttDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteProjekt(zespol.IdZespolu, It.IsAny<ZespolProjekt>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddPelnionaFunkcjaMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<PelnionaFunkcja>(It.IsAny<PelnionaFunkcjaDTO>()))
                .Returns((PelnionaFunkcjaDTO src) => new PelnionaFunkcja { });

            var pelnionaFunkcja = new PelnionaFunkcja();
            unitOfWorkMock.Setup(u => u.PelnioneFunkcje.InsertPelnionaFunkcja(pelnionaFunkcja));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var pelnionaFunkcjaDto = new PelnionaFunkcjaDTO();

            sekretarz.AddPelnionaFunkcja(pelnionaFunkcjaDto);
            unitOfWorkMock.Verify(repo => repo.PelnioneFunkcje.InsertPelnionaFunkcja(It.IsAny<PelnionaFunkcja>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemovePelnionaFunkcjaMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<PelnionaFunkcja>(It.IsAny<PelnionaFunkcjaDTO>()))
               .Returns((PelnionaFunkcjaDTO src) => new PelnionaFunkcja { });

            var pelnionaFunkcja = new PelnionaFunkcja();
            unitOfWorkMock.Setup(u => u.PelnioneFunkcje.InsertPelnionaFunkcja(pelnionaFunkcja));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var pelnionaFunkcjaDto = new PelnionaFunkcjaDTO();

            sekretarz.AddPelnionaFunkcja(pelnionaFunkcjaDto);
            sekretarz.RemovePelnionaFunkcja(pelnionaFunkcja.IdPelnionejFunkcji);

            unitOfWorkMock.Verify(repo => repo.PelnioneFunkcje.DeletePelnionaFunkcja(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }
        // AddPelnionaFunkcjaToUser             -       wiąże się z dodaniem UserPelnionaFunkcja
        // RemovePelnionaFunkcjaFromUser             -       wiąże się z dodaniem UserPelnionaFunkcja

        [Fact]
        public void TestAddSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var sprzet = new Sprzet();
            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var sprzetDto = new SprzetDTO();

            sekretarz.AddSprzet(sprzetDto);
            unitOfWorkMock.Verify(repo => repo.Sprzety.InsertSprzet(It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemoveSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var sprzet = new Sprzet();
            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var sprzetDto = new SprzetDTO();

            sekretarz.AddSprzet(sprzetDto);
            sekretarz.RemoveSprzet(sprzet.IdSprzetu);

            unitOfWorkMock.Verify(repo => repo.Sprzety.DeleteSprzet(It.IsAny<int>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddSprzetToTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var zespol = new Zespol() { };

            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Zespoly.AddSprzet(zespol.IdZespolu, sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var sprzetDto = new SprzetDTO();

            sekretarz.AddSprzetToTeam(zespol.IdZespolu, sprzetDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.AddSprzet(zespol.IdZespolu, It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }

        [Fact]
        public void TestRemoveSprzetFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Sprzet>(It.IsAny<SprzetDTO>()))
                .Returns((SprzetDTO src) => new Sprzet { });

            var zespol = new Zespol() { };
            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Zespoly.AddSprzet(zespol.IdZespolu, sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var sprzetDto = new SprzetDTO() { };

            sekretarz.AddSprzetToTeam(zespol.IdZespolu, sprzetDto);
            sekretarz.RemoveSprzetFromTeam(zespol.IdZespolu, sprzetDto);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteSprzet(zespol.IdZespolu, It.IsAny<Sprzet>()), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestAddProjektMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Projekt>(It.IsAny<ProjektDTO>()))
                .Returns((ProjektDTO src) => new Projekt { });

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt() { Nazwa = "Test", Opis = "Test", TerminRealizacji = DateTime.Now, IdZespolu = zespol.IdZespolu };
            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var projektDto = new ProjektDTO() { };

            sekretarz.AddProjekt(projektDto);
            unitOfWorkMock.Verify(repo => repo.Projekty.InsertProjekt(It.IsAny<Projekt>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save());
        }

        [Fact]
        public void TestRemoveProjektMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Projekt>(It.IsAny<ProjektDTO>()))
                .Returns((ProjektDTO src) => new Projekt { });

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var projekt = new Projekt() { Nazwa = "Test", Opis = "Test", TerminRealizacji = DateTime.Now };
            unitOfWorkMock.Setup(u => u.Projekty.InsertProjekt(projekt));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var projektDto = new ProjektDTO() { };

            sekretarz.AddProjekt(projektDto);
            sekretarz.RemoveProjekt(projekt.IdProjektu);
            unitOfWorkMock.Verify(repo => repo.Projekty.DeleteProjekt(It.IsAny<int>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save());
        }


        [Fact]
        public void TestGetEventMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var wydarzenie = new Wydarzenie();// { IdWydarzenia = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia)).Returns(wydarzenie);

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
            var wydarzenieDto = new WydarzenieDTO() { };

            sekretarz.GetEvent(wydarzenie.IdWydarzenia);

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia), Times.Once());
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once());
        }

        [Fact]          //!!!!!
        public void TestGetEventsMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            mockMapper.Setup(x => x.Map<Wydarzenie>(It.IsAny<WydarzenieDTO>()))
                .Returns((WydarzenieDTO src) => new Wydarzenie { });

            var wydarzenia = new List<Wydarzenie>() { };
            unitOfWorkMock.Setup(u => u.Wydarzenia.GetWydarzenia()).Returns(wydarzenia);

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object, mockMapper.Object);
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
