using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services;

public interface ICategoria
{
    public CategoriaDto SalvarCategoria(CategoriaDto categoria);
    public List<CategoriaDto> ListarCategorias();
    public CategoriaDto ObterCategoriaPeloId(int id);
    public bool AlterarDadoscategoria(int id, CategoriaDto categoria);
    public bool ApagarCategoria(int id);
}
