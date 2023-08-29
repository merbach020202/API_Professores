using System.Data.SqlClient;
using System.Reflection;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com o bancio de dados que recebe os seguintes parametros:
        /// Data Source : Nome do servidor 
        /// Initial catalog : Nome do banco de dados 
        /// Autenticação:
        ///     - Windows : Integrated Security = true
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE05-S15; Initial Catalog=Filmes_Eduardo; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualizar um gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        public void AtualizarIdCorpo(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    //Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    
                    //Abre a conexão com o bancod e dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string queryUpdate = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Buscar um gênero através do seu Id
        /// </summary>
        /// <param name="id">Id do gênero a ser buscado</param>
        /// <returns>Objeto buscado ou null caso não seja encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão passando a sring de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parâmetro nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um determinado gênero através do seu Id
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos (gêneros)
        /// </summary>
        /// <returns>Lista de objetos(gêneros)</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo gênero 
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados do rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),
                            //Atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona cada objeto dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }
            }

            //Retorna a lista de gêneros
            return ListaGeneros;
        }
    }
}
