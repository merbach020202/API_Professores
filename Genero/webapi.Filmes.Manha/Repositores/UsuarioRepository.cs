using System.Data.SqlClient;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE05-S15; Initial Catalog=Filmes_Eduardo; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(int id, UsuarioRepository genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, UsuarioRepository genero)
        {
            throw new NotImplementedException();
        }

        public UsuarioRepository BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioRepository novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioRepository> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Login(UsuarioRepository novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(Email) VALUES (@Email)"
            }
        }
    }
}
