using DAL.Repositories.CzlonekR;
using DAL.Repositories.PelnionaFunkcjaR;
using DAL.Repositories.ProjektR;
using DAL.Repositories.SprzetR;
using DAL.Repositories.WydarzenieR;
using DAL.Repositories.ZespolR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICzlonekRepository czlonek, IPelnionaFunkcjaRepository pelnionaFunkcja, IProjektRepository projekt, ISprzetRepository sprzet, IWydarzenieRepository wydarzenie, IZespolRepository zespol)
        {
            Czlonkowie = czlonek;
            PelnioneFunkcje = pelnionaFunkcja;
            Projekty = projekt;
            Sprzety = sprzet;
            Wydarzenia = wydarzenie;
            Zespoly = zespol;
        }

        public ICzlonekRepository Czlonkowie { get; private set; }

        public IPelnionaFunkcjaRepository PelnioneFunkcje { get; private set; }

        public IProjektRepository Projekty { get; private set; }

        public ISprzetRepository Sprzety { get; private set; }

        public IWydarzenieRepository Wydarzenia { get; private set; }

        public IZespolRepository Zespoly { get; set; }

        public void Dispose()
        {
            Czlonkowie.Dispose();
            PelnioneFunkcje.Dispose();
            Projekty.Dispose();
            Sprzety.Dispose();
            Wydarzenia.Dispose();
            Zespoly.Dispose();
        }

        public void Save()
        {
            Czlonkowie.Save();
            PelnioneFunkcje.Save();
            Projekty.Save();
            Sprzety.Save();
            Wydarzenia.Save();
            Zespoly.Save();
        }
    }
}
