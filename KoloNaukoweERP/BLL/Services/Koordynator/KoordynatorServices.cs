using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Koordynator
{
    public class KoordynatorServices : IKoordynatorServices
    {
        private readonly IUnitOfWork unitOfWork;
        public KoordynatorServices(IUnitOfWork unitOfWork)
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



        public void AddZespolToEvent(Zespol zespol, int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            wydarzenie.Zespol = zespol;
            unitOfWork.Save();
        }

        public void RemoveZespolFromEvent(Zespol zespol, int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            wydarzenie.Zespol = null;
            unitOfWork.Save();
        }
    }
}
