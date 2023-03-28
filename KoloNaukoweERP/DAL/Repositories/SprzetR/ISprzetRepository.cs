using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories.SprzetR
{
    public interface ISprzetRepository
    {
        IEnumerable<Sprzet> GetSprzet();
        Sprzet GetSprzetById(int idSprzetu);
        void InsertSprzet(Sprzet sprzet);
        void DeleteSprzet(int idSprzetu);
        void UpdateSprzet(Sprzet sprzet);
    }
}
