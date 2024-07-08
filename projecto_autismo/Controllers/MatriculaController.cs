using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Matricula")]
[ApiController]
public class MatriculaController : ControllerBase
{
    private IMatricula _matriculaInterface;
    public MatriculaController(IMatricula matriculaInterface)
    {
        _matriculaInterface = matriculaInterface;
    }

    [HttpPost]
    public IActionResult SalvarMatricula(MatriculaDto matricula)
    {
        var matriculaResult = _matriculaInterface.SalvarMatricula(matricula);

        return Ok(matriculaResult);
    }

    [HttpGet]
    public IActionResult ListarMatricula()
    {
        var matriculas = _matriculaInterface.ListarMatriculas();

        return Ok(matriculas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterMatriculapeloId(int id)
    {
        var matriculaResult = _matriculaInterface.ObterMatriculaPeloId(id);

        return Ok(matriculaResult);
    }

    [HttpDelete]
    public IActionResult ApagarMatricula(int id)
    {
        var result = _matriculaInterface.ApagarMatricula(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosAluno(int id, MatriculaDto matricula)
    {
        var result = _matriculaInterface.AlterarDadosMatricula(id, matricula);

        return Ok(result);
    }
}
