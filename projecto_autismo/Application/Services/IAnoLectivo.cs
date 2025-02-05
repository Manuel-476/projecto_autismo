using projecto_autismo.Application.Dto;
using projecto_autismo.Domain;

namespace projecto_autismo.Application.Services
{
    public interface IAnoLectivo
    {
        public bool AlterarDadosAnoLectivo(int id, AnoLectivoDto anoLectivo);

        public bool ApagarAnoLectivo(int id);

        public List<AnoLectivoDto> ListarAnos();

        public AnoLectivoDto ObterAnoLectivoPeloId(int id);

        public AnoLectivoDto SalvarAnoLectivo(AnoLectivoDto anoLectivo);

        public bool AlterarDadosTrimestre(int id, TrimestreDto trimestre);

        public bool ApagarTrimestre(int id);

        public List<TrimestreDto> ListarTrimestres();

        public TrimestreDto ObterTrimestrePeloId(int id);

        public TrimestreDto SalvarTrimestre(TrimestreDto trimestre);
    }
}
