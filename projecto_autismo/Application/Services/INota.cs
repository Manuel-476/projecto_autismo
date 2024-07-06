using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface INota
{
    public NotaDto SalvarNota(NotaDto nota);
    public List<NotaDto> ListarNotas();
    public NotaDto ObterNotaPeloId(int id);
    public bool AlterarDadosNota(int id, NotaDto nota);
    public bool ApagarNota(int id);
}
