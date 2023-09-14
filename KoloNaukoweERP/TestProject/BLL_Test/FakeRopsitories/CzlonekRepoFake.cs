using DAL.Entities;
using DAL.Repositories.CzlonekR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class CzlonekRepoFake : ICzlonekRepository
    {
        private List<Czlonek> czlonkowie = new List<Czlonek>();


        public IEnumerable<Czlonek> GetCzlonkowie()
        {
            return czlonkowie;
        }
        public Czlonek GetCzlonekById(int idCzlonka)
        {
            return czlonkowie.Find(cz => cz.IdCzlonka == idCzlonka);
        }
        public void InsertCzlonek(Czlonek czlonek)
        {
            czlonkowie.Add(czlonek);
        }
        public void DeleteCzlonek(int idCzlonka)
        {
            Czlonek czlonek = czlonkowie.Find(cz => cz.IdCzlonka == idCzlonka);
            czlonkowie.Remove(czlonek);
        }
        public void UpdateCzlonek(Czlonek czlonek)
        {
            int index = czlonkowie.FindIndex(cz => cz.IdCzlonka == czlonek.IdCzlonka);
            if (index != -1)
                czlonkowie[index] = czlonek;
        }
        public void InsertWypozyczenie(int idCzlonka, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }
        public void DeleteWypozyczenie(int idCzlonka, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void DeletePelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void InsertPelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void DeleteWydarzenie(int? idWydarzenia)
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
