using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.PelnionaFunkcjaR
{
    public interface IPelnionaFunkcjaRepository
    {
        IEnumerable<PelnionaFunkcja> GetPelnioneFunkcje();
        PelnionaFunkcja GetPelnionaFunkcjaById(int? idPelnionejFunkcji);
        void InsertPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja);
        void DeletePelnionaFunkcja(int? idPelnionejFunkcji);
        void UpdatePelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja);
        void Dispose();
        void Save();
    }
}
