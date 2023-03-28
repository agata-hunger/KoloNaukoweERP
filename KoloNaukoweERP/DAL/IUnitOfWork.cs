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
    public interface IUnitOfWork : IDisposable
    {
        ICzlonekRepository Czlonkowie { get; }

        IPelnionaFunkcjaRepository PelnioneFunkcje { get; }

        Repositories.ProjektR.IWydarzenieRepository Projekty { get; }
        ISprzetRepository Sprzety { get; }
        Repositories.WydarzenieR.IWydarzenieRepository Wydarzenia { get; }
        IZespolRepository Zespoly { get; }


        public void Save();

        public void Dispose();
    }
}
