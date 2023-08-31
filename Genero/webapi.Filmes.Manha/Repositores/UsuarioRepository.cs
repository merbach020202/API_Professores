using System.Data.SqlClient;
using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Interface;

namespace webapi.Filmes.Manha.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE05-S15; Initial Catalog=Filmes_Eduardo; User Id = sa; Pwd = Senai@134";
        
        //public UsuarioDomain BuscarLogin(string Email, string Senha)
        //{
        //    using (SqlConnection con = new SqlConnection(StringConexao))
        //    {
        //        string queryInsert = "SELECT Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

        //        con.Open();

        //        SqlDataReader rdr;

        //        using (SqlCommand cmd = new SqlCommand(queryInsert, con))
        //        {
        //            cmd.Parameters.AddWithValue("@Email", Email);
        //            cmd.Parameters.AddWithValue(@"Senha", Senha);

        //            rdr = cmd.ExecuteReader();

        //            if (rdr.Read())
        //            {
        //                UsuarioDomain usuarioBuscado = new UsuarioDomain
        //                {
        //                    Email = rdr["Email"].ToString(),
        //                    Senha = rdr["Senha"].ToString()
        //                };
        //                return usuarioBuscado;
        //            }

        //            return null;
        //        }
        //    }
        //}

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "SELECT Email, Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue(@"Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };
                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

    }
}