using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Sekretarz;
using WebAPI.Models;
using DAL.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WydarzeniaController : ControllerBase
    {
        private readonly ISekretarzServices sekretarzService;

        public WydarzeniaController(ISekretarzServices sekretarzService)
        {
            this.sekretarzService = sekretarzService;
        }

        // GET: Wydarzenia
        [HttpGet]
        public ActionResult<List<WydarzenieDTO>> Get()
        {
            return Ok(sekretarzService.GetEvents());
        }

        //GET: Wydarzenie 
        [HttpGet("{id}")]
        public ActionResult<WydarzenieDTO> Get([FromRoute] int id)
        {
            var wydarzenie = sekretarzService.GetEvent(id);
            if (id == null || wydarzenie == null) //sprawdzenie istnienia ID
            {
                return NotFound();
            }
            return Ok(wydarzenie);
        }

        [HttpPost]
        public ActionResult Create(WydarzenieDTO wydarzenie)
        {
            var zespol = sekretarzService.GetTeam(wydarzenie.IdZespolu);
            //sekretarzService.AddWydarzenie(wydarzenie);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(WydarzenieDTO wydarzenie)
        {
            //sekretarzService.RemoveWydarzenie(wydarzenie.Nazwa);
            return Ok();
        }
    }
}
