using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class FuncionarioRepository : IFuncionario
{
    private IMapper _mapper;
    public FuncionarioRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public bool AlterarDadosFuncionario(int id, FuncionarioDto funcionario)
    {
        var conector = new DbConnection();
        try
        {
            var newFuncionario = _mapper.Map<FuncionarioEntity>(funcionario);
            var oldFuncionario = conector.funcionario.Where(al => al.id == id).First();

            oldFuncionario.nome = newFuncionario.nome;
            oldFuncionario.genero = newFuncionario.genero;
            oldFuncionario.data_nascimento = newFuncionario.data_nascimento;
            oldFuncionario.endereco = newFuncionario.endereco;
            oldFuncionario.num_identificacao = newFuncionario.num_identificacao;
            oldFuncionario.funcao = newFuncionario.funcao;
            oldFuncionario.email = newFuncionario.email;
            oldFuncionario.virtuais = newFuncionario.virtuais;
            oldFuncionario.telefone = newFuncionario.telefone;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do : {ex.Message}");
        }
    }

    public bool ApagarFuncionario(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.funcionario.Where(fun => fun.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar Funcionario: {ex.Message}");
        }
    }

    public List<FuncionarioDto> ListarFuncionarios()
    {
        using var conector = new DbConnection();
        try
        {
            var funcionarios = conector.funcionario.ToList();

            var result = _mapper.Map<List<FuncionarioDto>>(funcionarios);

            return result;

        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar Funcionarios: {ex.Message}");
        }
    }

    public FuncionarioDto ObterFuncionarioPeloId(int id)
    {
        var conector = new DbConnection();
        try
        {
            var aluno = this.ListarFuncionarios().Where(al => al.id == id).First();

            return aluno;

        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao pegar id do Funcionario: {ex.Message}");
        }
    }

    public FuncionarioDto SalvarFuncionario(FuncionarioDto funcionario)
    {
        var conector = new DbConnection();

        try
        {
            var funcionarioEntity = _mapper.Map<FuncionarioEntity>(funcionario);

            conector.funcionario.Add(funcionarioEntity);
            conector.SaveChanges();

            var result = _mapper.Map<FuncionarioDto>(funcionarioEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar funcionario: {ex.Message}");
        }
    }
}
