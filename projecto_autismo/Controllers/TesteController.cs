using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Teste")]
[ApiController]
public class TesteController : ControllerBase
{
    private ITeste _testeInterface;
    public TesteController(ITeste testeInterface)
    {
        _testeInterface = testeInterface;
    }

    [HttpPost]
    public IActionResult SalvarTeste(TesteDto teste)
    {
        var testeResult = _testeInterface.SalvarTeste(teste);

        return Ok(testeResult);
    }

    [HttpGet]
    public IActionResult ListarTeste()
    {
        var testes = _testeInterface.ListarTestes();

        return Ok(testes);
    }

    [HttpGet("{id}")]
    public IActionResult ObterTestepeloId(int id)
    {
        var testeResult = _testeInterface.ObterTestePeloId(id);

        return Ok(testeResult);
    }

    [HttpDelete]
    public IActionResult ApagarTeste(int id)
    {
        var result = _testeInterface.ApagarTeste(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosAluno(int id, TesteDto teste)
    {
        var result = _testeInterface.AlterarDadosTestes(id, teste);

        return Ok(result);
    }
}
