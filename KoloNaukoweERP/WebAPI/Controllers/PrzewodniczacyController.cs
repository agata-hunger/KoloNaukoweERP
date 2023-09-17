using BLL.Models;
using BLL.Services.Koordynator;
using BLL.Services.ZastepcaPrzewodniczacego;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PrzewodniczacyController : Controller
    {
        private readonly IPrzewodniczacyServices przewodniczacyServices;

        public PrzewodniczacyController(IPrzewodniczacyServices przewodniczacyServices)
        {
            this.przewodniczacyServices = przewodniczacyServices;
        }

        [HttpPost]
        public IActionResult AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            przewodniczacyServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            przewodniczacyServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            przewodniczacyServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            przewodniczacyServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            przewodniczacyServices.AddCzlonekToTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            przewodniczacyServices.RemoveCzlonekFromTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            przewodniczacyServices.AddWydarzenieToTeam(idZespolu, wydarzenieDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            przewodniczacyServices.RemoveWydarzenieFromTeam(idZespolu, wydarzenieDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddProjektToTeam(int idZespolu, ProjektDTO projektDto)
        {
            przewodniczacyServices.AddProjektToTeam(idZespolu, projektDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDto)
        {
            przewodniczacyServices.RemoveProjektFromTeam(idZespolu, projektDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
            przewodniczacyServices.AddZespolToProject(idProjektu, zespolDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
            przewodniczacyServices.RemoveZespolFromProject(idProjektu, zespolDto);
            return View();
        }
    }
}
