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
    internal class UnitOfWork : IUnitOfWork
    {
        private DbKoloNaukoweERP context;
        UnitOfWork(DbKoloNaukoweERP context)
        {
            this.context = context;
            Czlonkowie = new CzlonekRepository(context);
            PelnioneFunkcje = new PelnionaFunkcjaRepository(context);
            Projekty = new ProjektRepository(context);
            Sprzety = new SprzetRepository(context);
            Wydarzenia = new WydarzenieRepository(context);
            Zespoly = new ZespolRepository(context);

        }

        public ICzlonekRepository Czlonkowie { get; private set; }

        public IPelnionaFunkcjaRepository PelnioneFunkcje { get; private set; }

        public Repositories.ProjektR.IWydarzenieRepository Projekty { get; private set; }
        public ISprzetRepository Sprzety { get; private set; }
        public Repositories.WydarzenieR.IWydarzenieRepository Wydarzenia { get; private set; }
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
