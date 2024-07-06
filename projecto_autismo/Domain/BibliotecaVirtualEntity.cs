namespace projecto_autismo.Domain
{
    public class BibliotecaVirtualEntity
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string endereco { get; set; }
        public string media { get; set; }
        public int categoriaId { get; set; }
        public int funcionarioId { get; set; }
        public CategoriaEntity categoria { get; set; }
        public FuncionarioEntity funcionario { get; set; }
    }
}
