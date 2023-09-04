using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public IActionResult GetByEmail(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);
            try
            {
                if (usuarioBuscado == null)
                {
                    return NotFound("Nenhum usuário encontrado!");
                }

                //Caso encontre o usuário, prossegue para a criação do token

                //Parte 1 - Definir as informações(claims) que serão fornecidas no token (PAYLOAD)
                var claims = new[]
                {
                    //Formato da claim 
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao),

                    //Exise a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                //Parte 2 - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                //Parte 3 - Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Parte 4 - Gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.Filmes.Manha",

                    //Destinatário do token
                    audience: "webapi.Filmes.Manha",

                    //dados definidos nas claims(informações)
                    claims : claims,

                    //Tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //Parte 5 - retornar um token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


                return Ok(usuarioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
