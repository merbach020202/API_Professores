using webapi.Filmes.Manha.Domains;

namespace webapi.Filmes.Manha.Interface
{
    public interface IFilmeRepository
    {
        //tipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos
        /// </summary>
        /// <returns>Lista com todos os obetos</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto atualizado</param>
        void AtualizarIdCorpo(FilmeDomain genero);


        /// <summary>
        /// Atualizar objeto existente atuaizando seu id pela URL
        /// </summary>
        /// <param name="id">Objeto atualizado (Novas informações)</param>
        /// <param name="genero"></param>
        void AtualizarIdUrl(int id, FilmeDomain filme);


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
        FilmeDomain BuscarPorId(int id);
    }
}
