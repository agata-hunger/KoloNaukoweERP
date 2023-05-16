using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Sekretarz;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Models;

namespace TestControllersMVC
{
    public class UnitTestWydarzenieApiController
    {
        [Fact]
        public void TestGetAction()
        {
            Mock<ISekretarzServices> mockSekretarzService = new Mock<ISekretarzServices>();

            var wydarzenia = new List<Wydarzenie>();

            mockSekretarzService
                .Setup(w => w.GetEvents())
                .Returns(wydarzenia);

            WydarzeniaController wydarzeniaController = new WydarzeniaController(mockSekretarzService.Object);
           
            var result = wydarzeniaController.Get();
            var actionResult = Assert.IsType<ActionResult<List<WydarzenieDTO>>>(result);
            var viewResult = Assert.IsType<ViewResult>(actionResult.Result);
            var model = Assert.IsAssignableFrom<List<Wydarzenie>>(viewResult.Model);

            Assert.Same(model, wydarzenia);
        }
    }
}
