using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ProjektR
{
    public class ProjektRepository : IProjektRepository, IDisposable
    {
        private DbKoloNaukoweERP context;
        
        ProjektRepository(DbKoloNaukoweERP context)
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
        protected virtual void Dispose(bool disposing)      // oba dispose i save w unitofwork
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
