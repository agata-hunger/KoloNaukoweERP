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
        private DbKoloNaukoweERP context;
        public UnitOfWork(DbKoloNaukoweERP context, ICzlonekRepository czlonek, IPelnionaFunkcjaRepository pelnionaFunkcja, IProjektRepository projekt, ISprzetRepository sprzet, IWydarzenieRepository wydarzenie, IZespolRepository zespol)
        {
            this.context = context;
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
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
