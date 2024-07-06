using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class TesteRepository : ITeste
{
    private IMapper _mapper;

    public TesteRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadosTestes(int id, TesteDto teste)
    {
        var conector = new DbConnection();
        try
        {
            var newTeste = _mapper.Map<TesteEntity>(teste);
            var oldTeste = conector.teste.Where(test => test.id == id).First();

            oldTeste.parcela = oldTeste.parcela;
            oldTeste.semestre = newTeste.semestre;
            oldTeste.ano = newTeste.ano;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do Teste: {ex.Message}");
        }
    }

    public bool ApagarTeste(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.teste.Where(test => test.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Teste: {ex.Message}");
        }
    }

    public List<TesteDto> ListarTestes()
    {
        using var conector = new DbConnection();
        try
        {
            var testes = conector.teste.ToList();

            var result = _mapper.Map<List<TesteDto>>(testes);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar Testes: {ex.Message}");
        }
    }

    public TesteDto ObterTestePeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var teste = this.ListarTestes().Where(teste => teste.id == id).First();

            return teste;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do teste: {ex.Message}");
        }
    }

    public TesteDto SalvarTeste(TesteDto teste)
    {
        var conector = new DbConnection();

        try
        {
            var testeEntity = _mapper.Map<TesteEntity>(teste);

            conector.teste.Add(testeEntity);

            conector.SaveChanges();

            var result = _mapper.Map<TesteDto>(testeEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar teste: {ex.Message}");
        }
    }
}
