using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Services.Uzytkownik
{
    public interface IUzytkownikServices
    {
        void AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        void RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto);
        public List<SprzetDTO> GetSprzet();
    }
}
