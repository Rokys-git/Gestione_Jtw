using gestione_jtw.Controllers;

namespace gestione_jtw.Models
{
    public class Autenticazione : AuthController
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Tipo { get; set; }

    }

}

