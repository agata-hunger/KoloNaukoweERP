using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.SprzetR
{
    public class SprzetRepository : ISprzetRepository
    {
        private DbKoloNaukoweERP context;

        public SprzetRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }

        public IEnumerable<Sprzet> GetSprzet()
        {
            return context.Sprzety.ToList();
        }

        public Sprzet GetSprzetById(int idSprzetu)
        {
            return context.Sprzety.Find(idSprzetu);
        }

        public void InsertSprzet(Sprzet sprzet)
        {
            context.Sprzety.Add(sprzet);
        }

        public void DeleteSprzet(int? idSprzetu)
        {
            Sprzet sprzet = context.Sprzety.Find(idSprzetu);
            context.Sprzety.Remove(sprzet);
        }

        public void UpdateSprzet(Sprzet sprzet)
        {
            context.Entry(sprzet).State = EntityState.Modified;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
