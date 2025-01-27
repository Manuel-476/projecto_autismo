using projecto_autismo.Application.Entity;

namespace projecto_autismo.Domain
{
    public class EncarregadoAlunoEntity
    {
        public int id { get; set; }
        public int encarregadoId { get; set; }
        public EncarregadoEntity? encarregado { get; set; }
        public int alunoId { get; set; }
        public AlunoEntity? aluno { get; set; }
    }
}
