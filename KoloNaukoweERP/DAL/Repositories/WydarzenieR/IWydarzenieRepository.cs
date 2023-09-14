using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.WydarzenieR
{
    public interface IWydarzenieRepository
    {
        IEnumerable<Wydarzenie> GetWydarzenia();
        Wydarzenie GetWydarzenieById(int idWydarzenia);
        void InsertWydarzenie(Wydarzenie wydarzenie);
        void DeleteWydarzenie(int? idWydarzenia);
        void UpdateWydarzenie(Wydarzenie wydarzenie);
        void InsertZespol(int idWydarzenia, Zespol zespol);
        void DeleteZespol(int idWydarzenia, Zespol zespol);
        void Dispose();
        void Save();
    }
}
