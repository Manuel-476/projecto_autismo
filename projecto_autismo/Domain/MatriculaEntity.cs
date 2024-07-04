namespace projecto_autismo.Domain
{
    public class MatriculaEntity
    {
        public int id {  get; set; }
        public int alunoId { get; set; }
        public AlunoEntity aluno { get; set; }
        public DateTime data { get; set; }
    }
}
