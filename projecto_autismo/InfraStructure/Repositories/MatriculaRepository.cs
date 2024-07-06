using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class MatriculaRepository : IMatricula
{
    private IMapper _mapper;

    public MatriculaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public bool AlterarDadosMatricula(int id, MatriculaDto matricula)
    {
        var conector = new DbConnection();
        try
        {
            var newMatricula = _mapper.Map<MatriculaEntity>(matricula);
            var oldMatricula = conector.matricula.Where(disc => disc.id == id).First();

            oldMatricula.data = oldMatricula.data;
            oldMatricula.alunoId = newMatricula.alunoId;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do matricula: {ex.Message}");
        }
    }

    public bool ApagarMatricula(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.matricula.Where(mat => mat.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Matricula: {ex.Message}");
        }
    }

    public List<MatriculaDto> ListarMatriculas()
    {
        using var conector = new DbConnection();
        try
        {
            var matriculas = conector.matricula.ToList();

            var result = _mapper.Map<List<MatriculaDto>>(matriculas);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar Matriculas: {ex.Message}");
        }
    }

    public MatriculaDto ObterMatriculaPeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var matricula = this.ListarMatriculas().Where(mat => mat.id == id).First();

            return matricula;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do Matricula: {ex.Message}");
        }
    }

    public MatriculaDto SalvarMatricula(MatriculaDto matricula)
    {
        var conector = new DbConnection();

        try
        {
            var matriculaEntity = _mapper.Map<MatriculaEntity>(matricula);

            conector.matricula.Add(matriculaEntity);

            conector.SaveChanges();

            var result = _mapper.Map<MatriculaDto>(matriculaEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar matricula: {ex.Message}");
        }
    }
}
