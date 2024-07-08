using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Funcionario")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private IFuncionario _funcionarioInterface;
    public FuncionarioController(IFuncionario funcionarioInterface)
    {
        _funcionarioInterface = funcionarioInterface;
    }

    [HttpPost]
    public IActionResult SalvarFuncionario(FuncionarioDto funcionario)
    {
        var funcionarioResult = _funcionarioInterface.SalvarFuncionario(funcionario);

        return Ok(funcionarioResult);
    }

    [HttpGet]
    public IActionResult ListarFuncionario()
    {
        var funcionarios = _funcionarioInterface.ListarFuncionarios();

        return Ok(funcionarios);
    }

    [HttpGet("{id}")]
    public IActionResult ObterFuncionariopeloId(int id)
    {
        var funcionarioResult = _funcionarioInterface.ObterFuncionarioPeloId(id);

        return Ok(funcionarioResult);
    }

    [HttpDelete]
    public IActionResult ApagarFuncionario(int id)
    {
        var result = _funcionarioInterface.ApagarFuncionario(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosFuncionario(int id, FuncionarioDto funcionario)
    {
        var result = _funcionarioInterface.AlterarDadosFuncionario(id, funcionario);

        return Ok(result);
    }
}
