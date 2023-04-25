using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services.Koordynator
{
    public interface IKoordynatorServices
    {
        void AddWypozyczenie(string nazwaSprzetu, int idCzlonka);
        void RemoveWypozyczenie(string nazwaSprzetu, int idCzlonka);
        

        void AddZespolToEvent(Zespol zespol, int idWydarzenia);
        void RemoveZespolFromEvent(Zespol zespol, int idWydarzenia);
    
        

    
    
    }
}
