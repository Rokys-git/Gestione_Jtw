using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FiltroUtente;

namespace gestione_jtw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Profilo : ControllerBase
    {
        [HttpPost ("Nuovo")]
        [FiltroUtente ("undimin")]
        // metodo che può esegiore l'admin
        
        public ActionResult soloadmin()
        {
            return Ok("sono solo un admin");
        }

        public ActionResult solouser()
        {
            return Ok("sono solo un user");
        }
        
    } 
}
