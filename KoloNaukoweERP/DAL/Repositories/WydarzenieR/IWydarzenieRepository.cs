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
        List<Wydarzenie> GetWydarzenia();
        Wydarzenie GetWydarzenieById(int idWydarzenia);
        void InsertWydarzenie(Wydarzenie wydarzenie);
        void DeleteWydarzenie(int idWydarzenia);
        void UpdateWydarzenie(Wydarzenie wydarzenie);
        void Dispose();
        void Save();
    }
}
