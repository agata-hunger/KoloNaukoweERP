using System;
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

namespace TestProject.BLL_Test
{
    public class WydarzenieServiceTest 
    {
        private readonly Mock<IWydarzenieRepository> mockWydarzenieRepo = new Mock<IWydarzenieRepository>();
        private readonly Mock<IZespolRepository> mockZespolRepo = new Mock<IZespolRepository>();
        private readonly Mock<ISprzetRepository> mockSprzetRepo = new Mock<ISprzetRepository>();
        private readonly Mock<IProjektRepository> mockProjektRepo = new Mock<IProjektRepository>();
        private readonly Mock<IPelnionaFunkcjaRepository> mockPelnionaFunkcjaRepo = new Mock<IPelnionaFunkcjaRepository>();
        private readonly Mock<ICzlonekRepository> mockCzlonekRepo = new Mock<ICzlonekRepository>();
        
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
        public void TestAddWydarzenieMoq()
        {
            Mock<IWydarzenieRepository> mockWydarzenieRepo = new Mock<IWydarzenieRepository>();
            Mock<IZespolRepository> mockZespolRepo = new Mock<IZespolRepository>();
            Mock<ISprzetRepository> mockSprzetRepo = new Mock<ISprzetRepository>();
            Mock<IProjektRepository> mockProjektRepo = new Mock<IProjektRepository>();
            Mock<IPelnionaFunkcjaRepository> mockPelnionaFunkcjaRepo = new Mock<IPelnionaFunkcjaRepository>();
            Mock<ICzlonekRepository> mockCzlonekRepo = new Mock<ICzlonekRepository>();

            var unitOfWork = new UnitOfWork(mockCzlonekRepo.Object, mockPelnionaFunkcjaRepo.Object, mockProjektRepo.Object, mockSprzetRepo.Object, mockWydarzenieRepo.Object, mockZespolRepo.Object);
            var sekretarzBLL = new SekretarzeServices(unitOfWork);

            sekretarzBLL.AddWydarzenie("Test", "Test", DateTime.Now, "Test");
            Assert.Equal(1, sekretarzBLL.GetEvents().Count());
        }
    public void RemoveWydarzenie(string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void AddWydarzenieToTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveWydarzenieFromTeam(string nazwaZespolu, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }


        public void AddZespolToEvent(Wydarzenie zespol, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void RemoveZespolFromEvent(Wydarzenie zespol, string nazwaWydarzenia)
        {
            throw new NotImplementedException();
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
