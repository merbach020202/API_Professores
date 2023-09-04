using System.ComponentModel.DataAnnotations;

namespace webapi.Filmes.Manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        public string Email { get; set; }

        
        [StringLength(20,MinimumLength = 6, ErrorMessage = "A senha deve ter de 6 a 20 caracteres ")]
        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        public string Senha { get; set; }
        public string Permissao { get; set; }

        
        //Referência para a classe gênero (Não é necessário, mas se tirar pode dar ruim)
        
        //public UsuarioDomain? Usuario { get; set; }
    }
}
