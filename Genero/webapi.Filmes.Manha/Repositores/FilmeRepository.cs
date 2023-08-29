using System.Data.SqlClient;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE05-S15, Initial Catalog=Filmes_Eduardo; User Id = sa; pwd = Senai@134";

        public void AtualizarIdCorpo (int id, FilmeDomain filme)
        {
            
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {

        }

        public FilmeDomain BuscarPorId(int id)
        {

        }

        public void Cadastrar(FilmeDomain novoFilme)
        {

        }

        public void Deletar(int id)
        {

        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con));
            }
        }


    }
}
