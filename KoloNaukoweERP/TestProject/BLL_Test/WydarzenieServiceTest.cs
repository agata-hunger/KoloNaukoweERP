using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Services.Sekretarz;
using DAL.Entities;
using DAL;

namespace TestProject.BLL_Test
{
    public class WydarzenieServiceTest 
    {
        private readonly DbKoloNaukoweERP context;



        [Fact]
        public void TestAddWydarzenie()//string nazwaWydarzenia, string nazwaZespolu, DateTime dataWydarzenia, string miejsceWydarzenia
        {
            var wydarzenieRepo = new WydarzenieRepoFake();
            var 
            var unitOfWork = new UnitOfWork(wydarzenieRepo);
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
        
    }
}
