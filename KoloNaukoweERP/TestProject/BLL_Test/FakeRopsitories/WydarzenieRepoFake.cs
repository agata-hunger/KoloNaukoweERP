using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DAL.Repositories.WydarzenieR;
using DAL.Entities;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class WydarzenieRepoFake : IWydarzenieRepository
    {
        private List<Wydarzenie> wydarzenia = new List<Wydarzenie>();


        public IEnumerable<Wydarzenie> GetWydarzenia()
        {
            return wydarzenia;
        }
        public Wydarzenie GetWydarzenieById(int idWydarzenia)
        {
            return wydarzenia.Find(w => w.IdWydarzenia == idWydarzenia);

        }
        public void InsertWydarzenie(Wydarzenie wydarzenie)
        {
            wydarzenia.Add(wydarzenie);
        }
        public void DeleteWydarzenie(int idWydarzenia)
        {
            Wydarzenie wydarzenie = wydarzenia.Find(w => w.IdWydarzenia == idWydarzenia);
            wydarzenia.Remove(wydarzenie);
        }
        public void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            int index = wydarzenia.FindIndex(w => w.IdWydarzenia == wydarzenie.IdWydarzenia);
            if (index != -1)
                wydarzenia[index] = wydarzenie;
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

