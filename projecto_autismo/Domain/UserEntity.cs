using projecto_autismo.Application.Dto;

namespace projecto_autismo.Domain
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string nomeUsuario { get; set; } = string.Empty;
        public string senha {  get; set; } = string.Empty;
        public int cargoId { get; set; }
        public CargoEntity? cargo { get; set; }
    }
}
