using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Koordynator
{
    internal class KoordynatorServices : IKoordynatorServices
    {
        private readonly IUnitOfWork unitOfWork;
        public KoordynatorServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddZespol(Zespol zespol, int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            wydarzenie.Zespol = zespol;
            unitOfWork.Save();
        }

        public void AddWypozyczenie(string nazwaSprzetu, int idWydarzenia)
        {
            //TO DO - id użytkownika w Urlu, rozwiązanie Zespol? nullable
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            var sprzety = wydarzenie.Zespol.Sprzety;
            if (sprzet != null)
            {
                sprzety.Add(sprzet);
            }
            unitOfWork.Save();
        }

        public void RemoveZespol(Zespol zespol, int idWydarzenia)
        {
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            wydarzenie.Zespol = null;
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, int idWydarzenia)
        {
            //TO DO -  rozwiązanie Zespol? nullable
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var wydarzenie = unitOfWork.Wydarzenia.GetWydarzenieById(idWydarzenia);
            var sprzety = wydarzenie.Zespol.Sprzety;
            if (sprzet != null)
            {
                sprzety.Remove(sprzet);
            }
            unitOfWork.Save();
        }
    }
}
