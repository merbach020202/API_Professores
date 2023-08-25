using webapi.Filmes.Manha.Domains;

namespace webapi.Filmes.Manha.Interface
{
    /// <summary>
    /// Interface responsável pelo repositório Genero repository
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo Genero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos
        /// </summary>
        /// <returns>Lista com todos os obetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualizar objeto existente atuaizando seu id pela URL
        /// </summary>
        /// <param name="id">Objeto atualizado (Novas informações)</param>
        /// <param name="genero"></param>
        void AtualizarIdUrl(int id, GeneroDomain genero);


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
        GeneroDomain BuscarPorId(int id);
    }
}
