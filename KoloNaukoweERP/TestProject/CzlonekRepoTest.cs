using DAL;
using DAL.Entities;
using DAL.Repositories.CzlonekR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class CzlonekRepoTest
    {
        [Fact]
        public void TestGetCzlonkowie()
        {
            var options = new DbContextOptionsBuilder<DbKoloNaukoweERP>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            var context = new DbKoloNaukoweERP(options);

            CzlonekRepository czlonekRepo = new CzlonekRepository(context);

            var czlonek = new Czlonek { IdCzlonka = 1, Imie = "Adam" };

            czlonekRepo.InsertCzlonek(czlonek);

            czlonekRepo.Save();

            Assert.Equal(1, czlonekRepo.GetCzlonkowie().Count());
                
        }



    }
}
