using projecto_autismo.Application.Dto;

namespace projecto_autismo.Application.Services
{
    public interface IUser
    {
        public bool AlterarDadosUser(int id, UserDto user);
        public bool ApagarUser(int id);
        public List<UserDto> ListarUsers();
        public UserDto ObterUserPeloId(int id);
        public UserDto SalvarUser(UserDto user);
        public List<CargoDto> ListarCargos();
        public CargoDto GetCargoPeloId(int cargoId);
        public UserResult AutorizarUser(UserDto user);
        public string Authenticacao(UserDto user);
        public UserDto VerificarUser(UserDto user);
        public CargoDto SalvarCargo(CargoDto cargo);
    }
}
