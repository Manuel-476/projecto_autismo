using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Turma")]
[ApiController]
public class TurmaController : ControllerBase
{
    private ITurma _turmaInterface;
    public TurmaController(ITurma turmaInterface)
    {
        _turmaInterface = turmaInterface;
    }

    [HttpPost]
    public IActionResult SalvarTurma(TurmaDto turma)
    {
        var turmaResult = _turmaInterface.SalvarTurma(turma);

        return Ok(turmaResult);
    }

    [HttpGet]
    public IActionResult ListarTurma()
    {
        var turmas = _turmaInterface.ListarTurmas();

        return Ok(turmas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterTurmapeloId(int id)
    {
        var turmaResult = _turmaInterface.ObterTurmaPeloId(id);

        return Ok(turmaResult);
    }

    [HttpDelete]
    public IActionResult ApagarTurma(int id)
    {
        var result = _turmaInterface.ApagarTurma(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosTurma(int id, TurmaDto turma)
    {
        var result = _turmaInterface.AlterarDadosTurmas(id, turma);

        return Ok(result);
    }
}
