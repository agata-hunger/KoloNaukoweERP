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
        public void AddUser(Czlonek czlonek, int idZespolu)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            zespol.Czlonkowie.Add(czlonek);
            unitOfWork.Save();
        }

        public void AddWypozyczenie(string nazwaSprzetu, int idZespolu)
        {
            //TO DO - id użytkownika w Urlu 
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            zespol.Sprzety.Add(sprzet);
            unitOfWork.Save();
        }

        public void RemoveUser(Czlonek czlonek, int idZespolu)
        {
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            zespol.Czlonkowie.Remove(czlonek);
            unitOfWork.Save();
        }

        public void RemoveWypozyczenie(string nazwaSprzetu, int idZespolu)
        {
            var sprzet = unitOfWork.Sprzety.GetSprzet().FirstOrDefault(sprzet => sprzet.Nazwa.Equals(nazwaSprzetu));
            var zespol = unitOfWork.Zespoly.GetZespolById(idZespolu);
            zespol.Sprzety.Remove(sprzet);
            unitOfWork.Save();
        }

        //public void UpdateUser(Czlonek czlonek, int idZespolu)
        //{

        //    throw new NotImplementedException();
        //}
    }
}
