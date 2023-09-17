using BLL.Models;
using BLL.Services.Uzytkownik;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzytkownikController : Controller
    {
        private readonly IUzytkownikServices uzytkownikServices;

        public UzytkownikController(IUzytkownikServices uzytkownikServices)
        {
            this.uzytkownikServices = uzytkownikServices;
        }

        [HttpPost]
        public ActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            try
            {
                uzytkownikServices.AddWypozyczenie(idCzlonka, sprzetDto);
                return RedirectToAction("Index", "Home"); // Przekierowanie na inną stronę po zakończeniu akcji
            }
            catch (Exception)
            {
                // Tutaj obsłuż błąd, na przykład zwróć widok z komunikatem o błędzie
                ViewBag.ErrorMessage = "Wystąpił błąd podczas dodawania wypożyczenia.";
                return View("Error");
            }
        }

        // Akcja do usuwania wypożyczenia
        [HttpDelete]
        public ActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            try
            {
                uzytkownikServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
                return RedirectToAction("Index", "Home"); // Przekierowanie na inną stronę po zakończeniu akcji
            }
            catch (Exception)
            {
                // Tutaj obsłuż błąd, na przykład zwróć widok z komunikatem o błędzie
                ViewBag.ErrorMessage = "Wystąpił błąd podczas usuwania wypożyczenia.";
                return View("Error");
            }
        }

        // Akcja do pobierania sprzętu
        [HttpGet]
        public ActionResult GetSprzet()
        {
            try
            {
                var sprzet = uzytkownikServices.GetSprzet();
                return View(sprzet); // Zwróć widok z listą sprzętu
            }
            catch (Exception)
            {
                // Tutaj obsłuż błąd, na przykład zwróć widok z komunikatem o błędzie
                ViewBag.ErrorMessage = "Wystąpił błąd podczas pobierania sprzętu.";
                return View("Error");
            }
        }
    }
}
