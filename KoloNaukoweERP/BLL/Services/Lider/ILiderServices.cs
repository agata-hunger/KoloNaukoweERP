using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lider
{
    public interface ILiderServices
    {
        void AddUser(Czlonek czlonek, int idZespolu);
        void RemoveUser(Czlonek czlonek, int idZespolu);
        //void UpdateUser(Czlonek czlonek, int idZespolu);
        void AddWypozyczenie(string nazwaSprzetu, int idZespolu);
        void RemoveWypozyczenie(string nazwaSprzetu, int idZespolu);
    }
}
