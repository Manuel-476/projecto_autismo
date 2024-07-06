using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;
using static System.Net.Mime.MediaTypeNames;

namespace projecto_autismo.InfraStructure.Repositories;

public class TurmaRepository : ITurma
{
    private IMapper _mapper;

    public TurmaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadosTurmas(int id, TurmaDto turma)
    {

        var conector = new DbConnection();
        try
        {
            var newTurma = _mapper.Map<TurmaEntity>(turma);
            var oldTurma = conector.turma.Where(turma => turma.id == id).First();

            oldTurma.turno = oldTurma.turno;
            oldTurma.descricao = newTurma.descricao;
            oldTurma.codigo = newTurma.codigo;
            oldTurma.disciplinas = newTurma.disciplinas;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do Turma: {ex.Message}");
        }
    }

    public bool ApagarTurma(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.turma.Where(turma => turma.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Turma: {ex.Message}");
        }
    }

    public List<TurmaDto> ListarTurmas()
    {
        using var conector = new DbConnection();
        try
        {
            var turmas = conector.turma.ToList();

            var result = _mapper.Map<List<TurmaDto>>(turmas);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar Turmas: {ex.Message}");
        }
    }

    public TurmaDto ObterTurmaPeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var turma = this.ListarTurmas().Where(turma => turma.id == id).First();

            return turma;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do turma: {ex.Message}");
        }
    }

    public TurmaDto SalvarTurma(TurmaDto turma)
    {
        var conector = new DbConnection();

        try
        {
            var turmaEntity = _mapper.Map<TurmaEntity>(turma);

            conector.turma.Add(turmaEntity);

            conector.SaveChanges();

            var result = _mapper.Map<TurmaDto>(turmaEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar turma: {ex.Message}");
        }
    }
}
