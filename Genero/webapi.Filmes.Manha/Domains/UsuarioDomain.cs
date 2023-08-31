using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.Manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }

        //Referência para a classe gênero
        public UsuarioDomain? Usuario { get; set; }
    }
}
