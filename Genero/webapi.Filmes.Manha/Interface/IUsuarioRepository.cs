using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Repositores;

namespace webapi.Filmes.Manha.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);

    }

}



