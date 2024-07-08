using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Vitrine")]
[ApiController]
public class VitrineController : ControllerBase
{
    private IVitrine _vitrineInterface;
    public VitrineController(IVitrine vitrineInterface)
    {
        _vitrineInterface = vitrineInterface;
    }

    [HttpPost]
    public IActionResult SalvarVitrine(VitrineDto vitrine)
    {
        var vitrineResult = _vitrineInterface.SalvarVitrine(vitrine);

        return Ok(vitrineResult);
    }

    [HttpGet]
    public IActionResult ListarAluno()
    {
        var vitrines = _vitrineInterface.ListarVitrines();

        return Ok(vitrines);
    }

    [HttpGet("{id}")]
    public IActionResult ObterVitrinePeloId(int id)
    {
        var vitrineResult = _vitrineInterface.ObterVitrinePeloId(id);

        return Ok(vitrineResult);
    }

    [HttpDelete]
    public IActionResult ApagarVitrine(int id)
    {
        var result = _vitrineInterface.ApagarVitrine(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosVitrine(int id, VitrineDto vitrine)
    {
        var result = _vitrineInterface.AlterarDadosVitrines(id, vitrine);

        return Ok(result);
    }
}
