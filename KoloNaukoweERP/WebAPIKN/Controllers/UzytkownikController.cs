using BLL.Models;
using BLL.Services.Uzytkownik;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIKN.Controllers
{
    public class UzytkownikController : Controller
    {
        private readonly IUzytkownikServices uzytkownikServices;

        public UzytkownikController(IUzytkownikServices uzytkownikServices)
        {
            this.uzytkownikServices = uzytkownikServices;
        }

        [HttpPost]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            uzytkownikServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
            // redirect do getWypozyczenie? / widoku wypozyczen?
        }

        [HttpDelete]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            uzytkownikServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }
    }
}
