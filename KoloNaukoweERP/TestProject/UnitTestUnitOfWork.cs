using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL_Test;

namespace TestProject
{
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var czlonekRepo = new CzlonekRepoDummy();
            var pelnionaFunkcjaRepo = new PelnionaFunkcjaRepoDummy();
            var projektRepo = new ProjektRepoDummy();
            var sprzetRepo = new SprzetRepoDummy();
            var wydarzenieRepo = new WydarzenieRepoDummy();
            var zespolRepo = new ZespolRepoDummy();

            var unitOfWork = new UnitOfWork(czlonekRepo,pelnionaFunkcjaRepo,projektRepo,sprzetRepo,wydarzenieRepo,zespolRepo);

            Assert.Same(czlonekRepo, unitOfWork.Czlonkowie);
            Assert.Same(pelnionaFunkcjaRepo, unitOfWork.PelnioneFunkcje);
            Assert.Same(projektRepo, unitOfWork.Projekty);
            Assert.Same(sprzetRepo, unitOfWork.Sprzety);
            Assert.Same(wydarzenieRepo, unitOfWork.Wydarzenia);
            Assert.Same(zespolRepo, unitOfWork.Zespoly);
        }
    }
}
