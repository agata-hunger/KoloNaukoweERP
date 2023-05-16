using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Sekretarz;
using DAL.Entities;
using Moq;
using WebAPIKN.Controllers;
using WebAPIKN.Models;

namespace TestControllersMVC
{
    public class UnitTestWydarzenieApiController
    {
        [Fact]
        public void TestGetAction()
        {
            Mock<ISekretarzServices> mockSekretarzService = new Mock<ISekretarzServices>();
            /*WydarzenieDTO wydarzenie = new WydarzenieDTO { Nazwa = "wydarzenie", IdZespolu = 1, Data = new DateTime(2023 - 05 - 16), Miejsce = "Katowice", IdWydarzenia = 1 };*/

            var wydarzenia = new List<Wydarzenie>();

            mockSekretarzService
                .Setup(w => w.GetEvents())
                .Returns(wydarzenia);


            WydarzeniaController wydarzeniaController = new WydarzeniaController(mockSekretarzService.Object);

            Assert.Same(wydarzeniaController.Get().Result, wydarzenia);
        }
    }
}
