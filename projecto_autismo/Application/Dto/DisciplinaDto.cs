using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class DisciplinaDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<TurmaDto>? turmas { get; set; }
        public List<NotaDto>? notas { get; set; }
        public List<FuncionarioDto>? funcionarios { get; set; }
    }
}
