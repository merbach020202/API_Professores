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

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
               string queryInsert  = "INSERT INTO Genero(Nome) VALUES ('" + novoGenero.Nome + "')";

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
