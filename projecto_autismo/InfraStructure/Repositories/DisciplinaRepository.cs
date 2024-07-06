using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class DisciplinaRepository : IDisciplina
{
    private IMapper _mapper;

    public DisciplinaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public bool AlterarDadosDisciplinas(int id, DisciplinaDto disciplina)
    {
        var conector = new DbConnection();
        try
        {
            var newDisciplina = _mapper.Map<DisciplinaEntity>(disciplina);
            var oldDisciplina = conector.disciplina.Where(disc => disc.id == id).First();

            oldDisciplina.turmas = oldDisciplina.turmas;
            oldDisciplina.descricao = newDisciplina.descricao;
            oldDisciplina.nome = newDisciplina.nome;
            oldDisciplina.funcionarios = newDisciplina.funcionarios;
            oldDisciplina.notas = newDisciplina.notas;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do disciplina: {ex.Message}");
        }
    }

    public bool ApagarDisciplina(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.disciplina.Where(disc => disc.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Disciplina: {ex.Message}");
        }
    }

    public List<DisciplinaDto> ListarDisciplinas()
    {
        using var conector = new DbConnection();
        try
        {
            var disciplinas = conector.disciplina.ToList();

            var result = _mapper.Map<List<DisciplinaDto>>(disciplinas);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar Disciplinas: {ex.Message}");
        }
    }

    public DisciplinaDto ObterDisciplinaPeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var disciplina = this.ListarDisciplinas().Where(disc => disc.id == id).First();

            return disciplina;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do Disciplina: {ex.Message}");
        }
    }

    public DisciplinaDto SalvarDisciplina(DisciplinaDto disciplina)
    {
        var conector = new DbConnection();

        try
        {
            var disciplinaEntity = _mapper.Map<DisciplinaEntity>(disciplina);
            
            conector.disciplina.Add(disciplinaEntity);

            conector.SaveChanges();

            var result = _mapper.Map<DisciplinaDto>(disciplinaEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar categoria: {ex.Message}");
        }
    }
}
