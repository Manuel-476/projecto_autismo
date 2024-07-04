namespace projecto_autismo.Domain
{
    public class TurmaEntity
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string turno { get; set; }
        public List<DisciplinaEntity> disciplinas { get; set; }
    }
}
