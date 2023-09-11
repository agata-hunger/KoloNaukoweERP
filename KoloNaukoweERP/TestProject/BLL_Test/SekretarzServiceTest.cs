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

namespace TestProject.BLL_Test
{
    public class SekretarzServiceTest 
    {   
        [Fact]
        public void TestAddWydarzenieMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            //zespolRepo.Setup(repo => repo.GetZespoly()).Returns(new List<Zespol> { zespol });
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespoly()).Returns(new List<Zespol> { zespol });

            var wydarzenie = new Wydarzenie();
            //wydarzenieRepo.Setup(repo => repo.InsertWydarzenie(wydarzenie));
            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));

 
            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

            unitOfWorkMock.Verify(repo => repo.Wydarzenia.InsertWydarzenie(It.IsAny<Wydarzenie>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
            
        }
        [Fact]
        public void TestAddWydarzenieToTeam()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);//.GetZespoly()).Returns(new List<Zespol> { zespol });

            var wydarzenie = new Wydarzenie();

            unitOfWorkMock.Setup(u => u.Wydarzenia.InsertWydarzenie(wydarzenie));
            unitOfWorkMock.Setup(u => u.Zespoly.InsertWydarzenie(zespol.IdZespolu, wydarzenie));//.InsertWyd(wydarzenie));
            

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

            var team = new Zespol();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(team));

            sekretarz.AddWydarzenieToTeam(1,wydarzenie);


            unitOfWorkMock.Verify(repo=>repo.Zespoly.InsertWydarzenie(1,It.IsAny<Wydarzenie>()),Times.Once());
        }
        [Fact]
        public void TestAddWydarzenie()//string nazwaWydarzenia, string nazwaZespolu, DateTime dataWydarzenia, string miejsceWydarzenia
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

            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

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

            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

            sekretarz.RemoveWydarzenie("Test");
            Assert.Equal(0, wydarzenieRepo.GetWydarzenia().Count());
        }

        /// <summary>
        /// ///

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
            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

            var team = new Zespol();
            unitOfWorkMock.Setup(u => u.Zespoly.InsertZespol(team));

            sekretarz.AddWydarzenieToTeam(1, wydarzenie);
            sekretarz.RemoveWydarzenieFromTeam(zespol.IdZespolu, wydarzenie);

            unitOfWorkMock.Verify(repo => repo.Zespoly.DeleteWydarzenie(wydarzenie.IdWydarzenia), Times.Once());
            //unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
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

            unitOfWorkMock.Verify(repo => repo.Zespoly.AddSprzet(zespol.IdZespolu,It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }
        public void TestRemoveSprzetFromTeamMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u => u.Zespoly.GetZespolById(zespol.IdZespolu)).Returns(zespol);

            var sprzet = new Sprzet();

            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));
            //unitOfWorkMock.Setup(u=>u.Zespoly.insert)
        }

        [Fact]
        public void TestAddSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var sprzet = new Sprzet() { Nazwa = "Test", Opis = "Test", CzyDostepny = true };
            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);

            sekretarz.AddSprzet(sprzet.Nazwa, sprzet.Opis, sprzet.CzyDostepny);
            unitOfWorkMock.Verify(repo => repo.Sprzety.InsertSprzet(It.IsAny<Sprzet>()), Times.Once);
            unitOfWorkMock.Verify(repo => repo.Save(), Times.Once);
        }
        [Fact]
        public void TestRemoveSprzetMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var sprzet = new Sprzet() { Nazwa = "Test", Opis = "Test", CzyDostepny = true };

            /*var sprzetRepositoryMock = new Mock<ISprzetRepository>();
            unitOfWorkMock.Setup(u => u.Sprzety).Returns(sprzetRepositoryMock.Object);*/


            unitOfWorkMock.Setup(u => u.Sprzety.InsertSprzet(sprzet));

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddSprzet(sprzet.Nazwa, sprzet.Opis, sprzet.CzyDostepny);

            sekretarz.RemoveSprzet(sprzet.IdSprzetu);
            unitOfWorkMock.Verify(repo => repo.Sprzety.DeleteSprzet(sprzet.IdSprzetu), Times.Once);
        }

        [Fact]
        public void TestAddZespolToEventMoq()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var wydarzenie = new Wydarzenie() { IdWydarzenia = 1, Nazwa = "Test" };
            unitOfWorkMock.Setup(u=>u.Wydarzenia.GetWydarzenieById(wydarzenie.IdWydarzenia)).Returns(wydarzenie);

            var zespol = new Zespol() { IdZespolu=1, Nazwa = "Test" };

            var sekretarz = new SekretarzeServices(unitOfWorkMock.Object);
            sekretarz.AddZespolToEvent(wydarzenie.IdWydarzenia, zespol);

            unitOfWorkMock.Verify(repo=> repo.Wydarzenia.InsertZespol(wydarzenie.IdWydarzenia, It.IsAny<Zespol>()), Times.Once);
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

        public Wydarzenie GetEvent(int idWydarzenia)
        {
            throw new NotImplementedException();
        }
        public List<Wydarzenie> GetEvents()
        {
            throw new NotImplementedException();
        }

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
