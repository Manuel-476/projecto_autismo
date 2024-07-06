using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class CategoriaRepository : ICategoria
{
    private IMapper _mapper;
    public CategoriaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadoscategoria(int id, CategoriaDto categoria)
    {
        var conector = new DbConnection();
        try
        {
            var newCategoria = _mapper.Map<CategoriaEntity>(categoria);
            var oldCategoria = conector.categoria.Where(cat => cat.id == id).First();

            oldCategoria.descricao = newCategoria.descricao;
            oldCategoria.categoria = newCategoria.categoria;
            oldCategoria.virtuais = newCategoria.virtuais;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do categoria: {ex.Message}");
        }
    }

    public bool ApagarCategoria(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.categoria.Where(cat => cat.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Categoria: {ex.Message}");
        }
    }

    public List<CategoriaDto> ListarCategorias()
    {
        using var conector = new DbConnection();
        try
        {
            var categorias = conector.categoria.ToList();

            var result = _mapper.Map<List<CategoriaDto>>(categorias);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar Categorias: {ex.Message}");
        }
    }

    public CategoriaDto ObterCategoriaPeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var categoria = this.ListarCategorias().Where(cat => cat.id == id).First();

            return categoria;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do Categoria: {ex.Message}");
        }
    }

    public CategoriaDto SalvarCategoria(CategoriaDto categoria)
    {
        var conector = new DbConnection();

        try
        {
            var categoriaEntity = _mapper.Map<CategoriaEntity>(categoria);

            conector.categoria.Add(categoriaEntity);
            conector.SaveChanges();

            var result = _mapper.Map<CategoriaDto>(categoriaEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar categoria: {ex.Message}");
        }
    }
}
