using DAL.Entities;
using DAL.Repositories.PelnionaFunkcjaR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class PelnionaFunkcjaRepoFake : IPelnionaFunkcjaRepository
    {
        private List<PelnionaFunkcja> pelnioneFunkcje = new List<PelnionaFunkcja>();


        public IEnumerable<PelnionaFunkcja> GetPelnioneFunkcje()
        {
            return pelnioneFunkcje;
        }
        public PelnionaFunkcja GetPelnionaFunkcjaById(int idPelnioneFunkcje)
        {
            return pelnioneFunkcje.Find(p => p.IdPelnionejFunkcji == idPelnioneFunkcje);

        }
        public void InsertPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            pelnioneFunkcje.Add(pelnionaFunkcja);
        }
        public void DeletePelnionaFunkcja(int? idPelnionejFunkcji)
        {
            PelnionaFunkcja pelnionaFunkcja = pelnioneFunkcje.Find(p => p.IdPelnionejFunkcji == idPelnionejFunkcji);
            pelnioneFunkcje.Remove(pelnionaFunkcja);
        }
        public void UpdatePelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            int index = pelnioneFunkcje.FindIndex(p => p.IdPelnionejFunkcji == pelnionaFunkcja.IdPelnionejFunkcji);
            if (index != -1)
                pelnioneFunkcje[index] = pelnionaFunkcja;
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
