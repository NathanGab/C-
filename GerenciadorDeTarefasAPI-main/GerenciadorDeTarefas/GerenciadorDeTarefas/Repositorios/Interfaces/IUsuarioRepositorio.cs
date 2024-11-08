using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<IUsuarioRepositorio>> BuscarTodosOsUsuarios();
        Task<UsuarioModel> BuscarporId(int id);
        Task <UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
