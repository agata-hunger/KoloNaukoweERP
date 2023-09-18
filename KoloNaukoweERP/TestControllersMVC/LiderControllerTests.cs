using BLL.Services.Lider;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIKN.Controllers;

namespace TestControllersMVC
{
    public class LiderControllerTests
    {
        [Fact]
        public void AddWypozyczenieTest()
        {
            Mock<ILiderServices> mockLiderServices = new Mock<ILiderServices>();

            //

            var liderController = new LiderController(mockLiderServices.Object);

            liderController.ControllerContext = new ControllerContext
            {
                //
            };

            //
            //
        }

        [Fact]
        public void RemoveWypozyczenieTest()
        {
            Mock<ILiderServices> mockLiderServices = new Mock<ILiderServices>();

            //

            var liderController = new LiderController(mockLiderServices.Object);

            liderController.ControllerContext = new ControllerContext
            {
                //
            };

            //
            //
        }

        [Fact]
        public void AddZespolToProjectTest()
        {
            Mock<ILiderServices> mockLiderServices = new Mock<ILiderServices>();

            //

            var liderController = new LiderController(mockLiderServices.Object);

            liderController.ControllerContext = new ControllerContext
            {
                //
            };

            //
            //
        }


        [Fact]
        public void RemoveZespolFromProjectTest()
        {
            Mock<ILiderServices> mockLiderServices = new Mock<ILiderServices>();

            //

            var liderController = new LiderController(mockLiderServices.Object);

            liderController.ControllerContext = new ControllerContext
            {
                //
            };

            //
            //
        }
    }
}
