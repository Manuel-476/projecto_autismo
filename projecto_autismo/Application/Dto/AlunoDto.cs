using projecto_autismo.Domain;
using static projecto_autismo.Application.Enums;

namespace projecto_autismo.Application.Entity
{
    public class AlunoDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public char genero { get; set; }
        public OpcaoBinaria deficiencia { get; set; }
        public string tipo_deficiencia { get; set; }
        public List<EncarregadoDto>? encarregados { get; set; }
        public MatriculaDto? matricula { get; set; }
    }
}
