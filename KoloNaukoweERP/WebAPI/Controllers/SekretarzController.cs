using BLL.Models;
using BLL.Services.Sekretarz;
using BLL.Services.Uzytkownik;
using BLL.Services.ZastepcaPrzewodniczacego;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class SekretarzController : Controller
    {
        private readonly ISekretarzServices sekretarzServices;

        public SekretarzController(ISekretarzServices sekretarzServices) 
        {
            this.sekretarzServices= sekretarzServices;
        }

        [HttpPost("addCzlonek")]
        public IActionResult AddCzlonek(CzlonekDTO czlonekDto)
        {
            sekretarzServices.AddCzlonek(czlonekDto);
            return View();
        }

        [HttpDelete("removeCzlonek")]
        public IActionResult RemoveCzlonek(int idCzlonka)
        {
            sekretarzServices.RemoveCzlonek(idCzlonka);
            return View();
        }

        [HttpPost("addCzlonekToTeam")]
        public IActionResult AddCzlonekToTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            sekretarzServices.AddCzlonekToTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpDelete("RemoveCzlonekFromTeam")]
        public IActionResult RemoveCzlonekFromTeam(int idZespolu, CzlonekDTO czlonekDto)
        {
            sekretarzServices.RemoveCzlonekFromTeam(idZespolu, czlonekDto);
            return View();
        }

        [HttpPost("addZespol")]
        public IActionResult AddZespol(ZespolDTO zespolDto)
        {
            sekretarzServices.AddZespol(zespolDto);
            return View();
        }

        [HttpDelete("removeZespol")]
        public IActionResult RemoveZespol(int? idZespolu)
        {
            sekretarzServices.RemoveZespol(idZespolu);
            return View();
        }

        [HttpPost("addWypozyczenie")]
        public IActionResult AddWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            sekretarzServices.AddWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpDelete("removeWypozyczenie")]
        public IActionResult RemoveWypozyczenie(int idCzlonka, SprzetDTO sprzetDto)
        {
            sekretarzServices.RemoveWypozyczenie(idCzlonka, sprzetDto);
            return View();
        }

        [HttpPost("addWydarzenie")]
        public IActionResult AddWydarzenie(WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.AddWydarzenie(wydarzenieDto);
            return View();
        }

        [HttpDelete("removeWydarzenie")]
        public IActionResult RemoveWydarzenie(int idWydarzenia)
        {
            sekretarzServices.RemoveWydarzenie(idWydarzenia);
            return View();
        }

        [HttpPost("addWydarzenieToTeam")]
        public IActionResult AddWydarzenieToTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.AddWydarzenieToTeam(idZespolu, wydarzenieDto);
            return View();
        }

        [HttpDelete("removeWydarzenieFromTeam")]
        public IActionResult RemoveWydarzenieFromTeam(int idZespolu, WydarzenieDTO wydarzenieDto)
        {
            sekretarzServices.RemoveWydarzenieFromTeam(idZespolu, wydarzenieDto);
            return View();
        }


        [HttpPost("addProjektToTeam")]
        public IActionResult AddProjektToTeam(int idZespolu, ProjektDTO projektDto)
        {
            sekretarzServices.AddProjektToTeam(idZespolu, projektDto);
            return View();
        }

        [HttpDelete("removeProjektFormTeam")]
        public IActionResult RemoveProjektFromTeam(int idZespolu, ProjektDTO projektDto)
        {
            sekretarzServices.RemoveProjektFromTeam(idZespolu, projektDto);
            return View();
        }

        /*[HttpPost("addZespolToProject")]
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
        }*/

        [HttpPost("addPelnionaFunkcja")]
        public IActionResult AddPelnionaFunkcja(PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcja(pelnionaFunkcjaDto);
            return View();
        }

        [HttpDelete("removePelnionaFunkcja")]
        public IActionResult RemovePelnionaFunkcja(int? idPelnionejFunkcji)
        {
            sekretarzServices.RemovePelnionaFunkcja(idPelnionejFunkcji);
            return View();
        }

        [HttpPost("addPelnionaFunkcjaToUser")]
        public IActionResult AddPelnionaFunkcjaToUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpDelete("removePelnionaFunkcjaFromUser")]
        public IActionResult RemovePelnionaFunkcjaFromUser(int idCzlonka, PelnionaFunkcjaDTO pelnionaFunkcjaDto)
        {
            sekretarzServices.AddPelnionaFunkcjaToUser(idCzlonka, pelnionaFunkcjaDto);
            return View();
        }

        [HttpPost("addSprzet")]
        public IActionResult AddSprzet(SprzetDTO sprzetDto)
        {
            sekretarzServices.AddSprzet(sprzetDto);
            return View();
        }

        [HttpDelete("removeSprzet")]
        public IActionResult RemoveSprzet(int idSprzetu)
        {
            sekretarzServices.RemoveSprzet(idSprzetu);
            return View();
        }

        [HttpPost("addSprzetToTeam")]
        public IActionResult AddSprzetToTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            sekretarzServices.AddSprzetToTeam(idZespolu, sprzetDto);
            return View();
        }

        [HttpDelete("removeSprzetFromTeam")]
        public IActionResult RemoveSprzetFromTeam(int idZespolu, SprzetDTO sprzetDto)
        {
            sekretarzServices.RemoveSprzetFromTeam(idZespolu, sprzetDto);
            return View();
        }

        [HttpPost("addProject")]
        public IActionResult AddProjekt(ProjektDTO projektDto)
        {
            sekretarzServices.AddProjekt(projektDto);
            return View();
        }

        [HttpDelete("removeProjekt")]
        public IActionResult RemoveProjekt(int idProjektu)
        {
            sekretarzServices.RemoveProjekt(idProjektu);
            return View();
        }

        [HttpGet("getEvent")]
        public ActionResult<WydarzenieDTO> GetEvent(int idWydarzenia)
        {
            sekretarzServices.GetEvent(idWydarzenia);
            return View();
        }

        [HttpGet("getEvents")]
        public ActionResult<IEnumerable<WydarzenieDTO>> GetEvents()
        {
            sekretarzServices.GetEvents();
            return View();
        }

        [HttpGet("getTeam")]
        public ActionResult<ZespolDTO> GetTeam(int idZespolu)
        {
            sekretarzServices.GetTeam(idZespolu);
            return View();
        }

        [HttpGet("getTeams")]
        public ActionResult<List<ZespolDTO>> GetTeams()
        {
            sekretarzServices.GetTeams();
            return View();
        }
    }
}
