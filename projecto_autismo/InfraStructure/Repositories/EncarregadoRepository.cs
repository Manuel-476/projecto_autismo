using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories
{
    public class EncarregadoRepository : IEncarregado
    {
        private IMapper _mapper;

        public EncarregadoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AlterarDadosEncarregado(int id, EncarregadoDto encarregado)
        {
            var conector = new DbConnection();
            try
            {
                var newEncarregado = _mapper.Map<EncarregadoEntity>(encarregado);
                var oldEncarregado = conector.encarregado.Where(en => en.id == id).First();

                oldEncarregado.nome = newEncarregado.nome;
                oldEncarregado.genero = newEncarregado.genero;
                oldEncarregado.email= newEncarregado.email;
                oldEncarregado.endereco = newEncarregado.endereco;
                oldEncarregado.telefone = newEncarregado.telefone;
                oldEncarregado.alunos = newEncarregado.alunos;

                conector.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar dados do Encarregado: {ex.Message}");
            }
        }

        public bool ApagarEncarregado(int id)
        {
            using var conector = new DbConnection();
            try
            {
                conector.encarregado.Where(en => en.id == id).ExecuteDelete();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar encarregado: {ex.Message}");
            }
        }

        public List<EncarregadoDto> ListarEncarregados()
        {
            using var conector = new DbConnection();
            try
            {
                var encarregados = conector.encarregado.ToList();

                var result = _mapper.Map<List<EncarregadoDto>>(encarregados);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ~pegar encarregado: {ex.Message}");
            }
        }

        public EncarregadoDto ObterEncarregadoPeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var encarregado = this.ListarEncarregados().Where(en => en.id == id).First();

                return encarregado;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar id do Encarregado: {ex.Message}");
            }
        }

        public EncarregadoDto SalvarEncarregado(EncarregadoDto encarregado)
        {
            var conector = new DbConnection();

            try
            {
                var encarregadoEntity = _mapper.Map<EncarregadoEntity>(encarregado);

                conector.encarregado.Add(encarregadoEntity);
                conector.SaveChanges();

                var result = _mapper.Map<EncarregadoDto>(encarregadoEntity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar aluno: {ex.Message}");
            }
        }
    }
}
