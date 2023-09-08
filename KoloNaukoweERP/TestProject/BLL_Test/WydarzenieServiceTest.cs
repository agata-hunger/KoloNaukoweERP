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
using System.Runtime.CompilerServices;

namespace TestProject.BLL_Test
{
    public class WydarzenieServiceTest 
    {   
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
            var wydarzenieRepo = new Mock<IWydarzenieRepository>();
            var zespolRepo = new Mock<IZespolRepository>();
            var sprzetRepo = new Mock<ISprzetRepository>();
            var projektRepo = new Mock<IProjektRepository>();
            var czlonekRepo = new Mock<ICzlonekRepository>();
            var pelnionaFunkcjaRepo = new Mock<IPelnionaFunkcjaRepository>();

            var zespol = new Zespol() { IdZespolu = 1, Nazwa = "Test" };
            zespolRepo.Setup(repo => repo.GetZespoly()).Returns(new List<Zespol> { zespol });

            var wydarzenie = new Wydarzenie();
            wydarzenieRepo.Setup(repo => repo.InsertWydarzenie(wydarzenie));

            var unitOfWork = new UnitOfWork(czlonekRepo.Object, pelnionaFunkcjaRepo.Object, projektRepo.Object, sprzetRepo.Object, wydarzenieRepo.Object, zespolRepo.Object);
            var sekretarz = new SekretarzeServices(unitOfWork);

            sekretarz.AddWydarzenie("Test", "Test", DateTime.Now, "Test");

            wydarzenieRepo.Verify(repo => repo.InsertWydarzenie(It.IsAny<Wydarzenie>()), Times.Once);
            wydarzenieRepo.Verify(repo => repo.Save(), Times.Once);
            
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
