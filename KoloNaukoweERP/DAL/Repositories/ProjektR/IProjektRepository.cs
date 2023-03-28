using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ProjektR
{
    public interface IProjektRepository
    {
        IEnumerable<Projekt> GetProjekty();
        Projekt GetProjektById(int idProjektu);
        void InsertProjekt(Projekt projekt);
        void DeleteProjekt(int idProjektu);
        void UpdateProjekt(Projekt projekt);
    }
}
