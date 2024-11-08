using GerenciadorDeTarefas.Enums;

namespace GerenciadorDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
