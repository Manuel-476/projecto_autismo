using projecto_autismo.Application.Dto;
using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class EncarregadoDto
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty ;
        public char genero { get; set; }
        public List<EncarregadoAlunoDto>? alunos { get; set; }
    }
}
