using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface IVitrine
{
    public VitrineDto SalvarVitrine(VitrineDto vitrine);
    public List<VitrineDto> ListarVitrines();
    public VitrineDto ObterVitrinePeloId(int id);
    public bool AlterarDadosVitrines(int id, VitrineDto vitrine);
    public bool ApagarVitrine(int id);
}
