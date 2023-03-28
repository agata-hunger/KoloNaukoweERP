using DAL.Entities;
using DAL.Repositories.ProjektR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.WydarzenieR
{
    public class WydarzenieRepository : IProjektRepository, IDisposable
    {
        private DbKoloNaukoweERP context;

        WydarzenieRepository(DbKoloNaukoweERP context)
        {
            this.context = context;
        }
        public IEnumerable<Projekt> GetProjekty()
        {
            return context.Projekty.ToList();
        }
        public Projekt GetProjektById(int idProjektu)
        {
            return context.Projekty.Find(idProjektu);
        }
        public void InsertProjekt(Projekt projekt)
        {
            context.Projekty.Add(projekt);
        }
        public void DeleteProjekt(int idProjektu)
        {
            Projekt projekt = context.Projekty.Find(idProjektu);
            context.Projekty.Remove(projekt);
        }
        public void UpdateProjekt(Projekt projekt)
        {
            context.Entry(projekt).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
