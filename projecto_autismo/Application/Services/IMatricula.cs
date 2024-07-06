using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface IMatricula
{
    public MatriculaDto SalvarMatricula(MatriculaDto matricula);
    public List<MatriculaDto> ListarMatriculas();
    public MatriculaDto ObterMatriculaPeloId(int id);
    public bool AlterarDadosMatricula(int id, MatriculaDto matricula);
    public bool ApagarMatricula(int id);
}
