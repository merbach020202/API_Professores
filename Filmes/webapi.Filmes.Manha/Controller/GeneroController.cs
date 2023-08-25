using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;
using webapi.Filmes.Manha.Repositores;

namespace webapi.Filmes.Manha.Controller
{
    //Define que a rota de uma requisição será no seguinte formato
    //Domínio/api/NomeController
    //Ex:http://localhost:500/api/genero
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoints (rotas)
    public class GeneroController : ControllerBase
    {

        /// <summary>
        /// Objeto_generoRepository que irá receber toods os métodos definidos pela interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos do repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o método ListarTodos no repositório e retorna a resposta para o usuário(Front_End)
        /// </summary>
        /// <returns>Retorna a resposta para o usuário(Front_end)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //Retorna a lista com formato JSON com o status code OK(200)
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna o sttus code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o método de cadastro genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>resposta para o usuário(front-End) </returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _generoRepository.Cadastrar(novoGenero);

                //Retorna o status code 201 - Created
                return StatusCode(201);
            }
            catch ( Exception erro)
            {
                //Retorna o sattus code 400(BadRequest) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
    }
}
