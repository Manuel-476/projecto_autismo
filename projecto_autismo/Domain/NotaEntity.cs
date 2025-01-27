namespace projecto_autismo.Domain
{
    public class NotaEntity
    {
        public int id { get; set; }
        public float nota1 { get; set; }
        public float nota2 { get; set; }
        public float nota3 { get; set; }
        public int disciplinaId { get; set; }
        public int alunoId { get; set; }
        public DisciplinaEntity? disciplina { get; set; }
    }
}
