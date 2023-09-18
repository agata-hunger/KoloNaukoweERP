using BLL.Models;
using BLL.Services.Koordynator;
using BLL.Services.Lider;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoordynatorController : Controller
    {
        public readonly IKoordynatorServices koordynatorServices;

        public KoordynatorController(IKoordynatorServices koordynatorServices)
        {
            this.koordynatorServices = koordynatorServices;
        }

        [HttpPost]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            koordynatorServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            koordynatorServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }
    }
}
