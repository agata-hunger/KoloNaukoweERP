using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lider
{
    public interface ILiderServices
    {
        void AddWypozyczenie(string nazwaSprzetu, int idCzlonka);
        void RemoveWypozyczenie(string nazwaSprzetu, int idCzlonka);


        void AddZespolToProject(Zespol zespol, int idProjektu);
        void RemoveZespolFromProject(Zespol zespol, int idProjektu);
    }
}
