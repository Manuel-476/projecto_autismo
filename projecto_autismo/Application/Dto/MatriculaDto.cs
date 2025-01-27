using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class MatriculaDto
    {
        public int id { get; set; }
        public int alunoId { get; set; }
       // public AlunoDto? aluno { get; set; }
        public DateTime data { get; set; }
    }
}
