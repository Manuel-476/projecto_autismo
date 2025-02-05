
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Dto;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories
{
    public class AnoLectivoRepository:IAnoLectivo
    {
        private IMapper _mapper;
        public AnoLectivoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool AlterarDadosAnoLectivo(int id, AnoLectivoDto anoLectivo)
        {
            var conector = new DbConnection();
            try
            {
                var newAnoLectivo = _mapper.Map<AnoLectivoEntity>(anoLectivo);
                var oldAnoLectivo = conector.anoLectivo.Where(en => en.id == id).First();

                oldAnoLectivo.ano = newAnoLectivo.ano;

                conector.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar dados do Ano Lectivo: {ex.Message}");
            }
        }

        public bool ApagarAnoLectivo(int id)
        {
            using var conector = new DbConnection();
            try
            {
                conector.anoLectivo.Where(en => en.id == id).ExecuteDelete();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar ano lectivo: {ex.Message}");
            }
        }

        public List<AnoLectivoDto> ListarAnos()
        {
            using var conector = new DbConnection();
            try
            {
                var anos = conector.anoLectivo.ToList();

                var result = _mapper.Map<List<AnoLectivoDto>>(anos);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar os anos: {ex.Message}");
            }
        }

        public AnoLectivoDto ObterAnoLectivoPeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var ano = this.ListarAnos().Where(en => en.id == id).First();

                return ano;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar id do Ano Lectivo: {ex.Message}");
            }
        }

        public AnoLectivoDto SalvarAnoLectivo(AnoLectivoDto anoLectivo)
        {
            var conector = new DbConnection();

            try
            {
                var anoLectivoEntity = _mapper.Map<AnoLectivoEntity>(anoLectivo);

                conector.anoLectivo.Add(anoLectivoEntity);
                conector.SaveChanges();

                var result = _mapper.Map<AnoLectivoDto>(anoLectivoEntity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar ano: {ex.Message}");
            }
        }

        public bool AlterarDadosTrimestre(int id, TrimestreDto trimestre)
        {
            var conector = new DbConnection();
            try
            {
                var newTrimestre = _mapper.Map<TrimestreEntity>(trimestre);
                var oldTrimestre = conector.trimestre.Where(en => en.id == id).First();

                oldTrimestre.anoLectivoId = newTrimestre.anoLectivoId;
                oldTrimestre.trimestre = newTrimestre.trimestre;

                conector.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar dados do Trimestre: {ex.Message}");
            }
        }

        public bool ApagarTrimestre(int id)
        {
            using var conector = new DbConnection();
            try
            {
                conector.trimestre.Where(en => en.id == id).ExecuteDelete();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar trimestre: {ex.Message}");
            }
        }

        public List<TrimestreDto> ListarTrimestres()
        {
            using var conector = new DbConnection();
            try
            {
                var anos = conector.trimestre.ToList();

                var result = _mapper.Map<List<TrimestreDto>>(anos);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar os trimestre: {ex.Message}");
            }
        }

        public TrimestreDto ObterTrimestrePeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var trimestre = this.ListarTrimestres().Where(en => en.id == id).First();

                return trimestre;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar id do trimestre: {ex.Message}");
            }
        }

        public TrimestreDto SalvarTrimestre(TrimestreDto trimestre)
        {
            var conector = new DbConnection();

            try
            {
                var trimestreEntity = _mapper.Map<TrimestreEntity>(trimestre);

                conector.trimestre.Add(trimestreEntity);
                conector.SaveChanges();

                var result = _mapper.Map<TrimestreDto>(trimestreEntity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar trimestre: {ex.Message}");
            }
        }
    }
}
