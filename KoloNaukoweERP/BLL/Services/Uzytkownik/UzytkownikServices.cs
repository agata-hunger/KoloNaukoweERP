using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Uzytkownik
{
    public class UzytkownikServices : IUzytkownikServices
    {
        private readonly IUnitOfWork unitOfWork;
        
        public UzytkownikServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddWypozyczenie(string nazwa, int idCzlonka)
        {
            //TO DO - id użytkownika w Urlu 
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwa));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            czlonek.Sprzety.Add(sprzet);
            unitOfWork.Save();
        }
        public void RemoveWypozyczenie(string nazwa, int idCzlonka)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwa));
            var czlonek = unitOfWork.Czlonkowie.GetCzlonekById(idCzlonka);
            czlonek.Sprzety.Remove(sprzet);
            unitOfWork.Save();
        }
    }
}
