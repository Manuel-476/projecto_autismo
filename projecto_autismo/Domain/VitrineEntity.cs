namespace projecto_autismo.Domain
{
    public class VitrineEntity
    {
        public int id {  get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dateTime { get; set; }
        public DateTime? created { get; set; }
        public int funcionarioId { get; set; }
        public FuncionarioEntity funcionario { get; set; }
    
    }
}
