using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.Repositories.WydarzenieR;
using DAL.Entities;

namespace TestProject.BLL_Test
{
    internal class WydarzenieRepoFake : IWydarzenieRepository
    {
        private List<Wydarzenie> wydarzenia = new List<Wydarzenie>();


        public IEnumerable<Wydarzenie> GetWydarzenia()
        {
            return this.wydarzenia;
        }
        public Wydarzenie GetWydarzenieById(int idWydarzenia)
        {
            return wydarzenia.Find(w => w.IdWydarzenia == idWydarzenia);

        }
        public void InsertWydarzenie(Wydarzenie wydarzenie)
        {
            this.wydarzenia.Add(wydarzenie);
        }
        public void DeleteWydarzenie(int idWydarzenia)
        {
            Wydarzenie wydarzenie = this.wydarzenia.Find(w => w.IdWydarzenia == idWydarzenia);
            this.wydarzenia.Remove(wydarzenie);
        }
        public void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            int index = this.wydarzenia.FindIndex(w => w.IdWydarzenia == wydarzenie.IdWydarzenia);
            if (index != -1)
                wydarzenia[index] = wydarzenie;
        }
    }
}

