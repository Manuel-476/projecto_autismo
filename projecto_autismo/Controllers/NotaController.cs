using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Nota")]
[ApiController]
public class NotaController : ControllerBase
{
    private INota _notaInterface;
    public NotaController(INota notaInterface)
    {
        _notaInterface = notaInterface;
    }

    [HttpPost]
    public IActionResult SalvarNota(NotaDto nota)
    {
        var notaResult = _notaInterface.SalvarNota(nota);

        return Ok(notaResult);
    }

    [HttpGet]
    public IActionResult ListarNota()
    {
        var notas = _notaInterface.ListarNotas();

        return Ok(notas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterNotapeloId(int id)
    {
        var notaResult = _notaInterface.ObterNotaPeloId(id);

        return Ok(notaResult);
    }

    [HttpDelete]
    public IActionResult ApagarNota(int id)
    {
        var result = _notaInterface.ApagarNota(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosNota(int id, NotaDto nota)
    {
        var result = _notaInterface.AlterarDadosNota(id, nota);

        return Ok(result);
    }
}
