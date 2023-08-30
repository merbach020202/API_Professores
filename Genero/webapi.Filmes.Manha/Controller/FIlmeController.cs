using Microsoft.AspNetCore.Mvc;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;
using webapi.Filmes.Manha.Repositores;

namespace webapi.Filmes.Manha.Controller
{
    //Ex: http://localhost:400/api/filme
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class FIlmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FIlmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();

                return Ok(ListaFilmes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum filme foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutId(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeAtualizado = _filmeRepository.BuscarPorId(id);

                if (filmeAtualizado == null)
                {
                    return NotFound("Inválido!");
                }

                filme.IdFilme = id;

                _filmeRepository.AtualizarIdUrl(id, filme);

                return Ok(filmeAtualizado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeExistente = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeExistente == null)
                {
                    return NotFound("Inválido");
                }

                _filmeRepository.AtualizarIdCorpo(filme);

                return Ok(filmeExistente);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
