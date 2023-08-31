using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;
using webapi.Filmes.Manha.Repositores;

namespace webapi.Filmes.Manha.Controller
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult GetByEmail(string Email, string Senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(Email, Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Nenhum usuário encontrado!");
                }

                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
