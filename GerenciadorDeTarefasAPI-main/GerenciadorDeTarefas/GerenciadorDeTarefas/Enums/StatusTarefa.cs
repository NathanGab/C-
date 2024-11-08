using System.ComponentModel;

namespace GerenciadorDeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("AFazer")]
        AFazer = 1,

        [Description("EmAndamento")]
        EmAndamento = 2,

        [Description("Concluido")]
        Concluido = 3
    }
}
