using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class VitrineDto
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dateTime { get; set; }
        public DateTime? created { get; set; }
        public FuncionarioDto funcionario { get; set; }
    }
}
