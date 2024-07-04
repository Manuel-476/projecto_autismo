namespace projecto_autismo.Domain
{
    public class CategoriaEntity
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string descricao { get; set; }
        public List<BibliotecaVirtualEntity> virtuais { get; set; }
    }
}
