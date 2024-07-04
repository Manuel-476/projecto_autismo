using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class TurmaDto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string turno { get; set; }
        public List<DisciplinaDto> disciplinas { get; set; }
    }
}
