using webapi.Filmes.Manha.Domains;
using webapi.Filmes.Manha.Repositores;

namespace webapi.Filmes.Manha.Interface
{
    public interface IUsuarioRepository
    {
        //tipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoUsuario">Objeto que será cadastrado</param>
        void Cadastrar(UsuarioRepository novoUsuario);

        /// <summary>
        /// Listar todos os objetos
        /// </summary>
        /// <returns>Lista com todos os obetos</returns>
        List<UsuarioRepository> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="usuario">Objeto atualizado</param>
        void AtualizarIdCorpo(int id, UsuarioRepository usuario);


        /// <summary>
        /// Atualizar objeto existente atuaizando seu id pela URL
        /// </summary>
        /// <param name="id">Objeto atualizado (Novas informações)</param>
        /// <param name="usuario"></param>
        void AtualizarIdUrl(int id, UsuarioRepository usuario);


        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">id do objeto que será deletado</param>
        void Deletar(int id);


        /// <summary>
        /// Busca um objeto através do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        UsuarioRepository BuscarPorId(int id);
    }
}
}


