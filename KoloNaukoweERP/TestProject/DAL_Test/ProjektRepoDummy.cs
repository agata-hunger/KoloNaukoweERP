using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.ProjektR;

namespace TestProject.DAL_Test
{
    public class ProjektRepoDummy : IProjektRepository
    {
        public void DeleteProjekt(int idProjektu)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Projekt GetProjektById(int idProjektu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projekt> GetProjekty()
        {
            throw new NotImplementedException();
        }

        public void InsertProjekt(Projekt projekt)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProjekt(Projekt projekt)
        {
            throw new NotImplementedException();
        }
    }
}
