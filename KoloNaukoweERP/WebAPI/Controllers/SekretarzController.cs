using BLL.Models;
using BLL.Services.Sekretarz;
using BLL.Services.Uzytkownik;
using BLL.Services.ZastepcaPrzewodniczacego;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class SekretarzController : Controller
    {
        private readonly ISekretarzServices sekretarzServices;

        public SekretarzController(ISekretarzServices sekretarzServices) 
        {
            this.sekretarzServices= sekretarzServices;
        }

        [HttpPost]
        public IActionResult AddCzlonek(CzlonekDTO czlonekDto)
        {
            sekretarzServices.AddCzlonek(czlonekDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveCzlonek(int idCzlonka)
        {
            sekretarzServices.RemoveCzlonek(idCzlonka);
            return View();
        }

        [HttpPost]
        public IActionResult AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            sekretarzServices.AddCzlonekToTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            sekretarzServices.RemoveCzlonekFromTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddZespol(ZespolDTO zespolDto)
        {
            sekretarzServices.AddZespol(zespolDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveZespol(int? idZespolu)
        {
            sekretarzServices.RemoveZespol(idZespolu);
            return View();
        }

        [HttpPost]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            sekretarzServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            sekretarzServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddWydarzenie(WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.AddWydarzenie(wydarzenieDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWydarzenie(int idWydarzenia)
        {
            sekretarzServices.RemoveWydarzenie(idWydarzenia);
            return View();
        }

        [HttpPost]
        public IActionResult AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.AddWydarzenieToTeam(idZespolu, wydarzenieDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.RemoveWydarzenieFromTeam(idZespolu, wydarzenieDto);
            return View();
        }


        [HttpPost]
        public IActionResult AddProjektToTeam(int idZespolu, ProjektDTO projektDto)
        {
            sekretarzServices.AddProjektToTeam(idZespolu, projektDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDto)
        {
            sekretarzServices.RemoveProjektFromTeam(idZespolu, projektDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddZespolToProject(int idProjektu, ZespolDTO zespolDto)
        {
            sekretarzServices.AddZespolToProject(idProjektu, zespolDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveZespolFromProject(int idProjektu, ZespolDTO zespolDto)
        {
            sekretarzServices.RemoveZespolFromProject(idProjektu, zespolDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddPelnionaFunkcja(PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcja(pelnionaFunkcjaDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemovePelnionaFunkcja(int? idPelnionejFunkcji)
        {
            sekretarzServices.RemovePelnionaFunkcja(idPelnionejFunkcji);
            return View();
        }

        [HttpPost]
        public IActionResult AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddSprzet(SprzetDTO sprzetDto)
        {
            sekretarzServices.AddSprzet(sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveSprzet(int idSprzetu)
        {
            sekretarzServices.RemoveSprzet(idSprzetu);
            return View();
        }

        [HttpPost]
        public IActionResult AddSprzetToTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            sekretarzServices.AddSprzetToTeam(idZespolu, sprzetDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveSprzetFromTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            sekretarzServices.RemoveSprzetFromTeam(idZespolu, sprzetDto);
            return View();
        }

        [HttpPost]
        public IActionResult AddProjekt(ProjektDTO projektDto)
        {
            sekretarzServices.AddProjekt(projektDto);
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveProjekt(int idProjektu)
        {
            sekretarzServices.RemoveProjekt(idProjektu);
            return View();
        }

        [HttpGet]
        public ActionResult<WydarzenieDTO> GetEvent(int idWydarzenia)
        {
            sekretarzServices.GetEvent(idWydarzenia);
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<WydarzenieDTO>> GetEvents()
        {
            sekretarzServices.GetEvents();
            return View();
        }

        [HttpGet]
        public ActionResult<ZespolDTO> GetTeam(int idZespolu)
        {
            sekretarzServices.GetTeam(idZespolu);
            return View();
        }

        [HttpGet]
        public ActionResult<List<ZespolDTO>> GetTeams()
        {
            sekretarzServices.GetTeams();
            return View();
        }
    }
}
