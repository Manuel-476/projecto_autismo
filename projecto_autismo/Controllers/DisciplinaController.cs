using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Disciplina")]
[ApiController]
public class DisciplinaController : ControllerBase
{
    private IDisciplina _disciplinaInterface;
    public DisciplinaController(IDisciplina disciplinaInterface)
    {
        _disciplinaInterface = disciplinaInterface;
    }

    [HttpPost]
    public IActionResult SalvarDisciplina(DisciplinaDto disciplina)
    {
        var disciplinaResult = _disciplinaInterface.SalvarDisciplina(disciplina);

        return Ok(disciplinaResult);
    }

    [HttpGet]
    public IActionResult ListarDisciplina()
    {
        var disciplinas = _disciplinaInterface.ListarDisciplinas();

        return Ok(disciplinas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterDisciplinapeloId(int id)
    {
        var disciplinaResult = _disciplinaInterface.ObterDisciplinaPeloId(id);

        return Ok(disciplinaResult);
    }

    [HttpDelete]
    public IActionResult ApagarDisciplina(int id)
    {
        var result = _disciplinaInterface.ApagarDisciplina(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosAluno(int id, DisciplinaDto disciplina)
    {
        var result = _disciplinaInterface.AlterarDadosDisciplinas(id, disciplina);

        return Ok(result);
    }
}
