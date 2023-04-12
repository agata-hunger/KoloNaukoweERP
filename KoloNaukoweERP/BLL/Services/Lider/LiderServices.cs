using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lider
{
    public class LiderServices : ILiderServices
    {
        private readonly IUnitOfWork unitOfWork;
        public LiderServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddWypozyczenie(string nazwaSprzetu, int idCzlonka)
        {
            //TO DO - id użytkownika w Urlu 
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            czlonek.Sprzety.Add(sprzet);
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, int idCzlonka)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            czlonek.Sprzety.Remove(sprzet);
            unitOfWork.Save();
        }

        public void AddZespolToProject(Zespol zespol, int idProjektu)
        {
            var projekt = unitOfWork.Wydarzenia.GetWydarzenieById(idProjektu);
            projekt.Zespol = zespol;
            unitOfWork.Save();
        }

        public void RemoveZespolFromProject(Zespol zespol, int idProjektu)
        {
            var projekt = unitOfWork.Wydarzenia.GetWydarzenieById(idProjektu);
            projekt.Zespol = null;
            unitOfWork.Save();
        }
    }
}
