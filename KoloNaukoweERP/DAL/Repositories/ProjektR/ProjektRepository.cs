﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ProjektR
{
    public class ProjektRepository : IWydarzenieRepository
    {
        private DbKoloNaukoweERP context;
        
        public ProjektRepository(DbKoloNaukoweERP context)
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
    }
}
