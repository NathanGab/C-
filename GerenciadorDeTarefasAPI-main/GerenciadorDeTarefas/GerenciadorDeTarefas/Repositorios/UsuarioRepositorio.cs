using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly GerenciadorTarefasDbContex _dbContext;
        public UsuarioRepositorio(GerenciadorTarefasDbContex gerenciadorTarefasDbContex )
        {
            _dbContext = gerenciadorTarefasDbContex;
        }

        public async Task<UsuarioModel> BuscarporId(int id)
        {
           return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosOsUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
             await _dbContext.Usuarios.AddAsync(usuario);
             await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
          UsuarioModel usuarioPorId = await BuscarporId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} mão foi encontrado no banco de dados ");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarporId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} mão foi encontrado no banco de dados ");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

       
    }
}
