using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.PelnionaFunkcjaR
{
    public class PelnionaFunkcjaRepository : IPelnionaFunkcjaRepository
    {
        private DbKoloNaukoweERP context;

        public PelnionaFunkcjaRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }

        public IEnumerable<PelnionaFunkcja> GetPelnioneFunkcje()
        {
            return context.PelnioneFunkcje.ToList();
        }

        public PelnionaFunkcja GetPelnionaFunkcjaById(int idPelnionejFunkcji)
        {
            return context.PelnioneFunkcje.Find(idPelnionejFunkcji);
        }

        public void InsertPelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            context.PelnioneFunkcje.Add(pelnionaFunkcja);
        }

        public void DeletePelnionaFunkcja(int idPelnionejFunkcji)
        {
            PelnionaFunkcja pelnionaFunkcja = context.PelnioneFunkcje.Find(idPelnionejFunkcji);
            context.PelnioneFunkcje.Remove(pelnionaFunkcja);
        }

        public void UpdatePelnionaFunkcja(PelnionaFunkcja pelnionaFunkcja)
        {
            context.Entry(pelnionaFunkcja).State = EntityState.Modified;
        }
    }
}

