using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Domain;
using projecto_autismo.Application.Services;
using projecto_autismo.InfraStructure.DataBase;
using System.Security.Cryptography.Xml;


namespace projecto_autismo.InfraStructure.Repositories
{
    public class AlunoRepository : IAluno
    {
        private IMapper _mapper;
        public AlunoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool ApagarAluno(int id)
        {
            using var conector = new  DbConnection();
            try
            {
                conector.aluno.Where(al => al.id == id).ExecuteDelete();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao apagar aluno: {ex.Message}");
            }
           
        }

        public AlunoDto ObterAlunoPeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var aluno = this.ListarAlunos().Where(al => al.id == id).First();

                return aluno;

            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao pegar id do Aluno: {ex.Message}");
            }
        }

        public List<AlunoDto> ListarAlunos()
        {
            using var conector = new DbConnection();
            try 
            {
                var alunos = conector.aluno.ToList();

                var result = _mapper.Map<List<AlunoDto>>(alunos);

                return result;

            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao ~pegar aluno: {ex.Message}");
            }
        }

        public AlunoDto SalvarAluno(AlunoDto aluno)
        {
            var conector = new DbConnection();

            try 
            {
                var alunoEntity = _mapper.Map<AlunoEntity>(aluno);

                conector.aluno.Add(alunoEntity);
                conector.SaveChanges();

                var result = _mapper.Map<AlunoDto>(alunoEntity);

                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu um erro ao salvar aluno: {ex.Message}");
            }
            
        }

        public bool AlterarDadosAluno(int id, AlunoDto aluno)
        {
            var conector = new DbConnection();
            try
            {
                var newAluno = _mapper.Map<AlunoEntity>(aluno);
                var oldAluno = conector.aluno.Where(al => al.id == id).First();

                oldAluno.nome = newAluno.nome;
                oldAluno.genero = newAluno.genero;
                oldAluno.data_nascimento = newAluno.data_nascimento;
                oldAluno.encarregados = newAluno.encarregados;
                oldAluno.deficiencia = newAluno.deficiencia;
                oldAluno.tipo_deficiencia = newAluno.tipo_deficiencia;
                oldAluno.matricula = newAluno.matricula;

                conector.SaveChanges();

                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro ao alterar dados do aluno: {ex.Message}");
            }
        }
    }
}
