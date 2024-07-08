using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Aluno")]
[ApiController]
public class AlunoController : ControllerBase
{
    private IAluno _alunoInterface;
    public AlunoController(IAluno alunoInterface)
    {
          _alunoInterface = alunoInterface;
    }

    [HttpPost]
    public IActionResult SalvarAluno(AlunoDto aluno) 
    {
        var alunoResult = _alunoInterface.SalvarAluno(aluno);

        return Ok(alunoResult);
    }

    [HttpGet]
    public IActionResult ListarAluno()
    {
        var alunos = _alunoInterface.ListarAlunos();

        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterAlunopeloId(int id)
    {
        var alunoResult = _alunoInterface.ObterAlunoPeloId(id);

        return Ok(alunoResult);
    }

    [HttpDelete]
    public IActionResult ApagarAluno(int id)
    {
        var result = _alunoInterface.ApagarAluno(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosAluno(int id,AlunoDto aluno)
    {
        var result = _alunoInterface.AlterarDadosAluno(id,aluno);

        return Ok(result);
    }

}
