namespace projecto_autismo.Domain
{
    public class FuncionarioEntity
    {
        public int id { get; set; }
        public string nome {  get; set; }
        public string num_identificacao { get; set; }
        public DateTime data_nascimento { get; set; }
        public string funcao { get; set; }
        public string endereco { get; set; }
        public char genero { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<BibliotecaVirtualEntity > virtuais { get; set; }
        public List<VitrineEntity> vitrines { get; set; }
    }
}
