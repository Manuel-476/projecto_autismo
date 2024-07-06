using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface IDisciplina
{
    public DisciplinaDto SalvarDisciplina(DisciplinaDto disciplina);
    public List<DisciplinaDto> ListarDisciplinas();
    public DisciplinaDto ObterDisciplinaPeloId(int id);
    public bool AlterarDadosDisciplinas(int id, DisciplinaDto disciplina);
    public bool ApagarDisciplina(int id);
}
