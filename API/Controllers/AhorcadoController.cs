using Microsoft.AspNetCore.Mvc;
using Application;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AhorcadoController : Controller
    {
        private readonly App _app;
        public AhorcadoController(App app)
        {
            _app = app;
        }

        [HttpGet]
        [HttpGet("{palabra}")]
        public ActionResult<AhorcadoResponse> NewGame(string palabra)
        {
            return Ok(_app.NewGame(palabra));
        }

        [HttpPost]
        public ActionResult<AhorcadoResponse> ArriesgarPalabra([FromBody] AhorcadoRequest rq)
        {
            return Ok(_app.ArriesgarPalabra(rq));
        }

        [HttpPost]
        public ActionResult<AhorcadoResponse> ArriesgarLetra([FromBody] AhorcadoRequest rq)
        {
            return Ok(_app.ArriesgarLetra(rq));
        }
    }
}