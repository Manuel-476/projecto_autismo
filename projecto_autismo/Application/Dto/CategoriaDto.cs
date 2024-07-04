using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class CategoriaDto
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string descricao { get; set; }
        public List<BibliotecaVirtualDto> virtuais { get; set; }
    }
}
