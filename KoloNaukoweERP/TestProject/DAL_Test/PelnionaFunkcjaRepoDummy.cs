using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.PelnionaFunkcjaR;

namespace TestProject.DAL_Test
{
    public class PelnionaFunkcjaRepoDummy : IPelnionaFunkcjaRepository
    {
        public void DeletePelnionaFunkcja(int? idPelnionejFunkcji)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public PelnionaFunkcja GetPelnionaFunkcjaById(int idPelnionejFunkcji)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PelnionaFunkcja> GetPelnioneFunkcje()
        {
            throw new NotImplementedException();
        }

        public void InsertPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }
    }
}
