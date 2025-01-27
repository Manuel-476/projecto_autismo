using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class DisciplinaDto
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        // public List<TurmaDto>? turmas { get; set; }
        public List<NotaDto>? notas { get; set; }
        public int funcionarioId { get; set; }
      //  public List<FuncionarioDto>? funcionarios { get; set; }
    }
}
