using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Dto;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin(UserDto user)
        {

            var result = _user.AutorizarUser(user);

            if (result == null)
            {
                return NotFound("Crendencias de usuario invalido!");
            }


            return Ok(result);
        }
        [HttpPost]
        public IActionResult SaveUsers(UserDto user)
        {
            var result = _user.SalvarUser(user);

            return Ok(result);
        }
        [HttpPost]
        [Route("cargo")]
        public IActionResult SaveCargo(CargoDto user)
        {
            var result = _user.SalvarCargo(user);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {

            var result = _user.ListarUsers();

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserPeloId(int userId)
        {

            var result = _user.GetCargoPeloId(userId);

            return Ok(result);
        }

        [HttpPut("{userId}/{user}")]
        public IActionResult UpdatePeloId(int userId, UserDto user)
        {
            var result = _user.AlterarDadosUser(userId,user);

            return Ok(result);
        }

        [HttpGet]
        [Route("cargo")]
        public IActionResult GetCargos()
        {

            var result = _user.ListarCargos();

            return Ok(result);
        }

        [HttpGet]
        [Route("cargo/{cargoId}")]
        public IActionResult GetCargoPeloId(int cargoId)
        {

            var result = _user.GetCargoPeloId(cargoId);

            return Ok(result);
        }
    }
}
