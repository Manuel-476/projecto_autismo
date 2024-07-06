using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class VitrineRepository : IVitrine
{
    private IMapper _mapper;

    public VitrineRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadosVitrines(int id, VitrineDto vitrine)
    {
        var conector = new DbConnection();
        try
        {
            var newVitrine = _mapper.Map<VitrineEntity>(vitrine);
            var oldVitrine = conector.vitrine.Where(vitrine =>  vitrine.id == id).First();

            oldVitrine.titulo = oldVitrine.titulo;
            oldVitrine.descricao = newVitrine.descricao;
            oldVitrine.dateTime = newVitrine.dateTime;
            oldVitrine.funcionarioId = newVitrine.funcionarioId;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do Vitrine: {ex.Message}");
        }
    }

    public bool ApagarVitrine(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.vitrine.Where(vitrine => vitrine.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Vitrine: {ex.Message}");
        }
    }

    public List<VitrineDto> ListarVitrines()
    {
        using var conector = new DbConnection();
        try
        {
            var vitrines = conector.vitrine.ToList();

            var result = _mapper.Map<List<VitrineDto>>(vitrines);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar Vitrines: {ex.Message}");
        }
    }

    public VitrineDto ObterVitrinePeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var vitrine = this.ListarVitrines().Where(vitrine => vitrine.id == id).First();

            return vitrine;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do vitrine: {ex.Message}");
        }
    }

    public VitrineDto SalvarVitrine(VitrineDto vitrine)
    {
        var conector = new DbConnection();

        try
        {
            var vitrineEntity = _mapper.Map<VitrineEntity>(vitrine);

            conector.vitrine.Add(vitrineEntity);

            conector.SaveChanges();

            var result = _mapper.Map<VitrineDto>(vitrineEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar vitrine: {ex.Message}");
        }
    }
}
