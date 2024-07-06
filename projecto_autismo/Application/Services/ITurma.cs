using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface ITurma
{
    public TurmaDto SalvarTurma(TurmaDto turma);
    public List<TurmaDto> ListarTurmas();
    public TurmaDto ObterTurmaPeloId(int id);
    public bool AlterarDadosTurmas(int id, TurmaDto turma);
    public bool ApagarTurma(int id);
}
