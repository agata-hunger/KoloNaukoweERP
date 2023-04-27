using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories.CzlonekR;

namespace TestProject.DAL_Test
{
    public class CzlonekRepoDummy : ICzlonekRepository
    {
        public void DeleteCzlonek(int idCzlonka)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Czlonek GetCzlonekById(int idCzlonka)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Czlonek> GetCzlonkowie()
        {
            throw new NotImplementedException();
        }

        public void InsertCzlonek(Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCzlonek(Czlonek czlonek)
        {
            throw new NotImplementedException();
        }
    }
}
