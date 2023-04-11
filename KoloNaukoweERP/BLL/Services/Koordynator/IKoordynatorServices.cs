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
        void AddZespol(Zespol zespol, int idWydarzenia);
        void RemoveZespol(Zespol zespol, int idWydarzenia);
        //void UpdateZespol(Zespol zespol, int idWydarzenia);
        void AddWypozyczenie(string nazwaSprzetu, int idWydarzenia);
        void RemoveWypozyczenie(string nazwaSprzetu, int idWydarzenia);
    }
}
