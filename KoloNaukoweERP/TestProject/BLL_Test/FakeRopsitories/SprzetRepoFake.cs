using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class SprzetRepoFake
    {
        private List<Sprzet> sprzety = new List<Sprzet>();


        public IEnumerable<Sprzet> GetSprzet()
        {
            return sprzety;
        }
        public Sprzet GetSprzetById(int idSprzety)
        {
            return sprzety.Find(s => s.IdSprzetu == idSprzety);

        }
        public void InsertSprzet(Sprzet sprzet)
        {
            sprzety.Add(sprzet);
        }
        public void DeleteSprzet(int idSprzetu)
        {
            Sprzet sprzet = sprzety.Find(s => s.IdSprzetu == idSprzetu);
            sprzety.Remove(sprzet);
        }
        public void UpdateSprzet(Sprzet sprzet)
        {
            int index = sprzety.FindIndex(s => s.IdSprzetu == sprzet.IdSprzetu);
            if (index != -1)
                sprzety[index] = sprzet;
        }
    }
}
