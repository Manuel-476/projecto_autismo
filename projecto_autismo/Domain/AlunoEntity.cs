using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static projecto_autismo.Application.Enums;

namespace projecto_autismo.Domain
{
    public class AlunoEntity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public char genero { get; set; }
        public OpcaoBinaria deficiencia {get; set;}
        public string tipo_deficiencia {get; set;}
        public List<EncarregadoEntity> encarregados { get; set; }
        public MatriculaEntity matricula { get; set; }
    }
}
