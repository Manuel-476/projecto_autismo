using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface ITeste
{
    public TesteDto SalvarTeste(TesteDto teste);
    public List<TesteDto> ListarTestes();
    public TesteDto ObterTestePeloId(int id);
    public bool AlterarDadosTestes(int id, TesteDto teste);
    public bool ApagarTeste(int id);
}
