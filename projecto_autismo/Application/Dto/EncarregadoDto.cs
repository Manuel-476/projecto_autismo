using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class EncarregadoDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public char genero { get; set; }
        public List<AlunoDto>? alunos { get; set; }
    }
}
