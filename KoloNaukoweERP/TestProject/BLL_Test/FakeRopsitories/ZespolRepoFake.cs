﻿using DAL.Entities;
using DAL.Repositories.ZespolR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.BLL_Test.FakeRopsitories
{
    public class ZespolRepoFake : IZespolRepository
    {
        private List<Zespol> zespoly = new List<Zespol>();


        public IEnumerable<Zespol> GetZespoly()
        {
            return zespoly;
        }
        public Zespol GetZespolById(int idZespoly)
        {
            return zespoly.Find(z => z.IdZespolu == idZespoly);

        }
        public void InsertZespol(Zespol zespol)
        {
            zespoly.Add(zespol);
        }
        public void DeleteZespol(int? idZespolu)
        {
            Zespol wydarzenie = zespoly.Find(z => z.IdZespolu == idZespolu);
            zespoly.Remove(wydarzenie);
        }
        public void UpdateZespol(Zespol zespol)
        {
            int index = zespoly.FindIndex(z => z.IdZespolu == zespol.IdZespolu);
            if (index != -1)
                zespoly[index] = zespol;
        }
        public void InsertWydarzenie(int idZespolu, ZespolWydarzenie zespolWydarzenie)
        {
            throw new NotImplementedException();
        }
        public void DeleteWydarzenie(int idZespolu, ZespolWydarzenie zespolWydarzenie)
        {
            throw new NotImplementedException();
        }
        public void AddSprzet(int idZespolu, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            //do nothing
        }

        public void Save()
        {
            //do nothing
        }

        public void DeleteSprzet(int idSprzetu)
        {
            throw new NotImplementedException();
        }

        public void InsertCzlonek(int idZespolu, Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void DeleteCzlonek(int idczlonka)
        {
            throw new NotImplementedException();
        }

        public void DeleteWydarzenie(int idZespolu, Wydarzenie wydarzenie)
        {
            throw new NotImplementedException();
        }

        public void DeleteCzlonek(int idZespolu, Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void DeleteSprzet(int idZespolu, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void InsertProjekt(int idZespolu, ZespolProjekt zespolProjekt)
        {
            throw new NotImplementedException();
        }

        public void DeleteProjekt(int idZespolu, ZespolProjekt zespolProjekt)
        {
            throw new NotImplementedException();
        }
    }
}