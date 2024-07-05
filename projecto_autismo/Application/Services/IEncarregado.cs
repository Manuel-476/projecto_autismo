using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services
{
    public interface IEncarregado
    {
        public EncarregadoDto SalvarEncarregado(EncarregadoDto encarregado);
        public List<EncarregadoDto> ListarEncarregados();
        public EncarregadoDto ObterEncarregadoPeloId(int id);
        public bool AlterarDadosEncarregado(int id, EncarregadoDto encarregado);
        public bool ApagarEncarregado(int id);

    }
}
