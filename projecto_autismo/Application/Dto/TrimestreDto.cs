using static projecto_autismo.Application.Enums;

namespace projecto_autismo.Application.Dto
{
    public class TrimestreDto
    {
        public int id { get; set; }
        public int anoLectivoId { get; set; }
        public Trimestre trimestre { get; set; }
        DateTime created { get; set; }
    }
}
