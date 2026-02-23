using gestione_jtw.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gestione_jtw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AuthController : ControllerBase
    {
        [HttpPost("login")]

        public ActionResult login(Autenticazione account)
        {
            if ((account.Username == "admin") && (account.Password == "admin"))
            {
                account.Tipo = "admin";
            }
            if ((account.Username == "User") && (account.Password == "User"))
            {
                account.Tipo = "User";
            }
            if (account.Tipo == null)
            {
                return BadRequest("account non valido");
            }
            //compongo il mio token definendo i claims
            //genero il token e popolo le pro della fig.1 ossia i claims
            List<Claim> ListaClaims = new List<Claim>()
 {
     new Claim(JwtRegisteredClaimNames.Sub,account.Username), //il sub lo definisce il cliente
     new Claim("UserType",account.Tipo),
     new Claim("Personalizzato","tutto quello che voglio"),
     new Claim("Email","email presa dal database"),
     new Claim("campo2","valore..."),
     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString() )//identificativo univoco
 };
            //definisco la chiave x la cifratura del mio algoritmo
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("la mia mia chiave"));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("corso_talentform!corso_talentform"));
            //abbino la mia chiave all algoritmo
            var credenziali = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //creo il token
            var mioTokenJwt = new JwtSecurityToken(issuer: "mio sito", audience: "indirizzo api",//issuer e audience stabiliti in program.cs
                claims: ListaClaims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credenziali
                );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(mioTokenJwt) });
            return Ok();
        }
    }
}
