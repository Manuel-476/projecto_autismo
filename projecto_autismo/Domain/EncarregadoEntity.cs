namespace projecto_autismo.Domain
{
    public class EncarregadoEntity
    {
        public int  id {  get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public char genero { get; set; }
        public List<AlunoEntity> alunos { get; set; }
    }
}
