using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.SprzetR;

namespace TestProject.DAL_Test
{
    public class SprzetRepoDummy : ISprzetRepository
    {
        public void DeleteSprzet(int? idSprzetu)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sprzet> GetSprzet()
        {
            throw new NotImplementedException();
        }

        public Sprzet GetSprzetById(int idSprzetu)
        {
            throw new NotImplementedException();
        }

        public void InsertSprzet(Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateSprzet(Sprzet sprzet)
        {
            throw new NotImplementedException();
        }
    }
}
