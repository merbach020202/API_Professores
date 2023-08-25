using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.Manha.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        
        //Referência para a classe gênero
        public GeneroDomain? Genero { get; set; }

    }
}
