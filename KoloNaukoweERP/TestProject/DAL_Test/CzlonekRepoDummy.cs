﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL;
using DAL.Entities;
using DAL.Repositories.CzlonekR;

namespace TestProject.DAL_Test
{
    public class CzlonekRepoDummy : ICzlonekRepository
    {
        public IEnumerable<Czlonek> GetCzlonkowie()
        {
            throw new NotImplementedException();
        }

        public Czlonek GetCzlonekById(int? idCzlonka)
        {
            throw new NotImplementedException();
        }

        public void InsertCzlonek(Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void DeleteCzlonek(int idCzlonka)
        {
            throw new NotImplementedException();
        }

        public void UpdateCzlonek(Czlonek czlonek)
        {
            throw new NotImplementedException();
        }

        public void InsertWypozyczenie(int idCzlonka, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void DeleteWypozyczenie(int idCzlonka, Sprzet sprzet)
        {
            throw new NotImplementedException();
        }

        public void InsertPelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void DeletePelnionaFunkcja(int idCzlonka, PelnionaFunkcja pelnionaFunkcja)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
