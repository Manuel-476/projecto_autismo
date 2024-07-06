using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface IBiblioteca
{
    public BibliotecaVirtualDto SalvarMedia(BibliotecaVirtualDto bVirtual);
    public List<BibliotecaVirtualDto> ListarMedias();
    public BibliotecaVirtualDto ObterMediaPeloId(int id);
    public object GetDownloadMedia(int id);
    public bool AlterarDadosMedia(int id, BibliotecaVirtualDto bVirtual);
    public bool ApagarMedia(int id);
}
