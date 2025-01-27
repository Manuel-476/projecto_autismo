using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Dto
{
    public class EncarregadoAlunoDto
    {
        public int id { get; set; }
        public int encarregadoId { get; set; }
        public EncarregadoDto? encarregado { get; set; }
        public int alunoId { get; set; }
        public AlunoDto? aluno { get; set; }
        
    }
}
