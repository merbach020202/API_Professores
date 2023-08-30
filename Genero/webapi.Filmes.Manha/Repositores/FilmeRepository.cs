using System.Data.SqlClient;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE05-S15; Initial Catalog=Filmes_Eduardo; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE iDfILME = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Titulo FROM Filme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        ListaFilmes.Add(filme);
                    }
                }
            }

            return ListaFilmes;
        }


    }
}
