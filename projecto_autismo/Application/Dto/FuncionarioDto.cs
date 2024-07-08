using projecto_autismo.Domain;

namespace projecto_autismo.Application.Entity
{
    public class FuncionarioDto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string num_identificacao { get; set; }
        public DateTime data_nascimento { get; set; }
        public string funcao { get; set; }
        public string endereco { get; set; }
        public char genero { get; set; }
        public string telefone { get; set; }
        public string email { get; set; } = string.Empty;
        public ICollection<BibliotecaVirtualDto>? virtuais { get; set; }
    }
}
