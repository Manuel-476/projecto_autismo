using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application;
using projecto_autismo.Application.Dto;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace projecto_autismo.InfraStructure.Repositories
{
    public class UserRepository:IUser
    {
        private IMapper _mapper;
        private string[] args;
        public UserRepository(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public UserResult AutorizarUser(UserDto user)
        {
            UserDto userData = null;
            UserResult userResult = null;

            if (this.VerificarUser(user) != null)
            {
                userData = this.VerificarUser(user);
                userResult = new UserResult();
            }

            if (userData == null)
            {
                return null;
            }
            else
            {
                userResult.token = this.Authenticacao(userData);
                userResult.user = userData;

                return userResult;
            }
        }

        public string Authenticacao(UserDto user)
        {
            var builder = WebApplication.CreateBuilder(args);

            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier, user.nomeUsuario),
             new Claim(ClaimTypes.Role, this.GetCargoPeloId(user.cargoId).cargo),
            };

            var token = new JwtSecurityToken
                (
                    issuer: builder.Configuration["Jwt:Issuer"],
                    audience: builder.Configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                                        SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public CargoDto SalvarCargo(CargoDto cargo)
        {
            var conector = new DbConnection();

            try
            {
                var cargoEntity = _mapper.Map<CargoEntity>(cargo);

                conector.cargo.Add(cargoEntity);
                conector.SaveChanges();

                var result = _mapper.Map<CargoDto>(cargoEntity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar user: {ex.Message}");
            }
        }

        public UserDto VerificarUser(UserDto user)
        {
            try
            {
                using var getConnection = new DbConnection();

                UserDto userResult = null;

                foreach (var userItem in this.ListarUsers().Where(x => x.nomeUsuario == user.nomeUsuario).ToList())
                {
                    var password = user.senha;

                    userResult = _mapper.Map<UserDto>(getConnection.user.FirstOrDefault(us => us.nomeUsuario.Equals(user.nomeUsuario) && us.senha.Equals(password)));

                    if (userResult != null)
                    {
                        break;
                    }
                }

                UserDto userDTO = _mapper.Map<UserDto>(userResult);

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao verificar as credenciais do usuario: {ex.Message}");
            }

        }

        public bool AlterarDadosUser(int id, UserDto user)
        {
            var conector = new DbConnection();
            try
            {
                var newUser = _mapper.Map<UserEntity>(user);
                var oldUser = conector.user.Where(en => en.Id == id).First();

                oldUser.nomeUsuario = newUser.nomeUsuario;
                oldUser.senha = newUser.senha;
                oldUser.cargoId = newUser.cargoId;

                conector.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar dados do User: {ex.Message}");
            }
        }

        public bool ApagarUser(int id)
        {
            using var conector = new DbConnection();
            try
            {
                conector.user.Where(en => en.Id == id).ExecuteDelete();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao apagar User: {ex.Message}");
            }
        }

        public List<UserDto> ListarUsers()
        {
            using var conector = new DbConnection();
            try
            {
                var users = conector.user.ToList();

                var result = _mapper.Map<List<UserDto>>(users);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar user: {ex.Message}");
            }
        }

        public List<CargoDto> ListarCargos()
        {
            using var conector = new DbConnection();
            try
            {
                var users = conector.cargo.ToList();

                var result = _mapper.Map<List<CargoDto>>(users);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar os cargos: {ex.Message}");
            }
        }

        public CargoDto GetCargoPeloId(int cargoId)
        {
            using var conector = new DbConnection();
            try
            {
                if (conector.cargo.Where(x => x.id == cargoId).Any())
                {
                    var users = conector.cargo.Where(x => x.id == cargoId).First();

                    var result = _mapper.Map<CargoDto>(users);

                    return result;
                }
                else 
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar os cargos: {ex.Message}");
            }
        }

        public UserDto ObterUserPeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var user = this.ListarUsers().Where(en => en.Id == id).First();

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar id do user: {ex.Message}");
            }
        }

        public UserDto SalvarUser(UserDto user)
        {
            var conector = new DbConnection();

            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);

                conector.user.Add(userEntity);
                conector.SaveChanges();

                var result = _mapper.Map<UserDto>(userEntity);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar user: {ex.Message}");
            }
        }
    }

}
public class UserResult
{
    public string token { get; set; } = string.Empty;
    public UserDto? user { get; set; }
}