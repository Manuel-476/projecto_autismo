namespace projecto_autismo.Domain
{
    public class DisciplinaEntity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public List<TurmaEntity> turmas { get; set; }
        public List<NotaEntity> notas { get; set; }
        public List<FuncionarioEntity> funcionarios { get; set; }
    }
}
