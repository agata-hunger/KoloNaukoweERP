using DAL.Entities;
using DAL.Repositories.ProjektR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class ProjektRepoFake : IProjektRepository
    {
        private List<Projekt> projekty = new List<Projekt>();


        public IEnumerable<Projekt> GetProjekty()
        {
            return projekty;
        }
        public Projekt GetProjektById(int idProjektu)
        {
            return projekty.Find(p => p.IdProjektu == idProjektu);

        }
        public void InsertProjekt(Projekt projekt)
        {
            projekty.Add(projekt);
        }
        public void DeleteProjekt(int idProjektu)
        {
            Projekt projekt = projekty.Find(p => p.IdProjektu == idProjektu);
            projekty.Remove(projekt);
        }
        public void UpdateProjekt(Projekt projekt)
        {
            int index = projekty.FindIndex(p => p.IdProjektu == projekt.IdProjektu);
            if (index != -1)
                projekty[index] = projekt;
        }
    }
}
