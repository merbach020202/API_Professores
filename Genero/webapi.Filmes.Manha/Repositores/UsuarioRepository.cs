using System.Data.SqlClient;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE05-S15; Initial Catalog=Filmes_Eduardo; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "SELECT IdUsuario, Email, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue(@"Senha", Senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    {
                        if (rdr.Read())
                        {
                            UsuarioDomain usuarioBuscado = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = Convert.ToString(rdr["Email"]),
                                Permissao = Convert.ToString(rdr["Permissao"]),
                            };

                            return usuarioBuscado;
                        }
                        else
                        {
                        //Se não tiver nunguém dentro do if para ser lido retorne o valor nulo(por isso return null no final)
                        return null;
                        }
                    }
                }
            }

        }
    }
}