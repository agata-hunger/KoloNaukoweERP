using BLL.Services.Lider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIKN.Controllers;
using Moq;
using BLL.Models;
using BLL.Services.Sekretarz;
using Microsoft.AspNetCore.Mvc;

namespace TestControllersMVC
{
    public class LiderAPIControllerTests
    {
        [Fact]
        public void AddWypozyczenieOkTest()
        {
            var mockLiderService = new Mock<ILiderServices>();

            var controller = new LiderController(mockLiderService.Object);
            var idCzlonka = 1;

            var sprzet = new SprzetDTO
            {
                IdSprzetu = 1,
                Nazwa = "TestNazwa",
                CzyDostepny = true
            };

            var result = controller.AddWypozyczenie(idCzlonka, sprzet) as OkResult;

            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
            mockLiderService.Verify(s => s.AddWypozyczenie(idCzlonka, sprzet), Times.Once());
        }

        [Fact]
        public void RemoveWypozyczenieOkTest()
        {
            var mockLiderService = new Mock<ILiderServices>();

            var controller = new LiderController(mockLiderService.Object);
            var idCzlonka = 1;

            var sprzet = new SprzetDTO
            {
                IdSprzetu = 1,
                Nazwa = "TestNazwa",
                CzyDostepny = true
            };

            var result = controller.RemoveWypozyczenie(idCzlonka, sprzet) as OkResult;

            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
            mockLiderService.Verify(s => s.RemoveWypozyczenie(idCzlonka, sprzet), Times.Once());
        }

        [Fact]
        public void AddZespolToProjectOkTest()
        {
            var mockLiderService = new Mock<ILiderServices>();

            var controller = new LiderController(mockLiderService.Object);
            var idProjektu = 1;

            var zespol = new ZespolDTO
            {
                IdZespolu = 1,
                Nazwa = "TestNazwa"
            };

            var result = controller.AddZespolToProject(idProjektu, zespol) as OkResult;

            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
            mockLiderService.Verify(s => s.AddZespolToProject(idProjektu, zespol), Times.Once());
        }

        [Fact]
        public void RemoveZespolFromProjectOkTest()
        {
            var mockLiderService = new Mock<ILiderServices>();

            var controller = new LiderController(mockLiderService.Object);
            var idProjektu = 1;

            var zespol = new ZespolDTO
            {
                IdZespolu = 1,
                Nazwa = "TestNazwa"
            };

            var result = controller.RemoveZespolFromProject(idProjektu, zespol) as OkResult;

            //Assert.NotNull(result);
            //Assert.Equal(200, result.StatusCode);
            mockLiderService.Verify(s => s.RemoveZespolFromProject(idProjektu, zespol), Times.Once());
        }
    }
}
