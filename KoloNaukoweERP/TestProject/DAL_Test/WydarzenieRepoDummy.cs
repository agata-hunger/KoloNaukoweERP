using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.WydarzenieR;

namespace TestProject.DAL_Test
{
    public class WydarzenieRepoDummy : IWydarzenieRepository
    {
        public void DeleteWydarzenie(int idWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wydarzenie> GetWydarzenia()
        {
            throw new NotImplementedException();
        }

        public Wydarzenie GetWydarzenieById(int idWydarzenia)
        {
            throw new NotImplementedException();
        }

        public void InsertWydarzenie(Wydarzenie wydarzenie)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateWydarzenie(Wydarzenie wydarzenie)
        {
            throw new NotImplementedException();
        }
        public void InsertZespol(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
        public void DeleteZespol(int idWydarzenia, Zespol zespol)
        {
            throw new NotImplementedException();
        }
    }
}
