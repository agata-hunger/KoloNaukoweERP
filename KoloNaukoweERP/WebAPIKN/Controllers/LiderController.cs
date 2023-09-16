using BLL.Models;
using BLL.Services.Lider;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIKN.Controllers
{
    public class LiderController : Controller
    {
        private readonly ILiderServices liderServices;

        public LiderController(ILiderServices liderServices)
        {
            this.liderServices = liderServices;
        }

        [HttpPost]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            liderServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            liderServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
            liderServices.AddZespolToProject(idProjektu, zespolDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
            liderServices.RemoveZespolFromProject(idProjektu, zespolDto);
            return View();
        }
    }
}
