using BLL.Services.Sekretarz;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIKN.Controllers;
using WebAPIKN.Models;

namespace TestControllersMVC
{
    public class UnitTestWydarzenieController
    {
        [Fact]
        public void TestGetAction()
        {
            Mock<ISekretarzServices> mockSekretarzServices = new Mock<ISekretarzServices>();

            var wydarzenia = new List<Wydarzenie>();
            
            mockSekretarzServices
                .Setup(w => w.GetEvents())
                .Returns(wydarzenia);

            WydarzeniaController wydarzeniaController = new WydarzeniaController(mockSekretarzServices.Object);

            var result = wydarzeniaController.Get();
            var actionResult = Assert.IsType<ActionResult<List<WydarzenieDTO>>>(result);
            var viewResult = Assert.IsType<ViewResult>(actionResult.Result);
            var model = Assert.IsAssignableFrom<List<Wydarzenie>>(viewResult.Model);

            Assert.Same(viewResult.Model, wydarzenia);
        }
    }
}
