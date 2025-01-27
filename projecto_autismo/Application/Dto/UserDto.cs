namespace projecto_autismo.Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string nomeUsuario { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;
        public int cargoId { get; set; }
        public CargoDto? cargo { get; set; }
    }
}
