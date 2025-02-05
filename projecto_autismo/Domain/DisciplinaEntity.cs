namespace projecto_autismo.Domain
{
    public class DisciplinaEntity
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;

       // public List<TurmaEntity> turmas { get; set; }
        //public List<NotaEntity>? notas { get; set; }
        public int funcionarioId { get; set; }
        //  public List<FuncionarioEntity> funcionarios { get; set; }
    }
}
