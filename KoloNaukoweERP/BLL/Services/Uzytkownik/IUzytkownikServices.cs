using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services.Uzytkownik
{
    public interface IUzytkownikServices
    {
        void AddWypozyczenie(string nazwa, int idCzlonka);
        void RemoveWypozyczenie(string nazwa, int idCzlonka);
    }
}
