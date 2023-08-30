using Microsoft.AspNetCore.Mvc;

namespace webapi.Filmes.Manha.Controller
{
    public class UsuarioController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
