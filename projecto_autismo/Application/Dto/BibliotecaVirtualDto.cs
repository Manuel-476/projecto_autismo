using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class BibliotecaVirtualDto
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string endereco { get; set; }
        public int categoriaId { get; set; }
        public int funcionarioId { get; set; }
        public CategoriaDto categoria { get; set; }
        public FuncionarioDto funcionario { get; set; }
    }
}
