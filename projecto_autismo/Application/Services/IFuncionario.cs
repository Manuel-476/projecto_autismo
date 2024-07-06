using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface IFuncionario
{
    public FuncionarioDto SalvarFuncionario(FuncionarioDto funcionario);
    public List<FuncionarioDto> ListarFuncionarios();
    public FuncionarioDto ObterFuncionarioPeloId(int id);
    public bool AlterarDadosFuncionario(int id, FuncionarioDto funcionario);
    public bool ApagarFuncionario(int id);
}
