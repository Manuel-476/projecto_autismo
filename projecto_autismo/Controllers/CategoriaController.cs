using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers;
[Route("api/Categoria")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private ICategoria _categoriaInterface;
    public CategoriaController(ICategoria categoriaInterface)
    {
        _categoriaInterface = categoriaInterface;
    }

    [HttpPost]
    public IActionResult SalvarCategoria(CategoriaDto categoria)
    {
        var categoriaResult = _categoriaInterface.SalvarCategoria(categoria);

        return Ok(categoriaResult);
    }

    [HttpGet]
    public IActionResult ListarCategoria()
    {
        var categorias = _categoriaInterface.ListarCategorias();

        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult ObterCategoriapeloId(int id)
    {
        var categoriaResult = _categoriaInterface.ObterCategoriaPeloId(id);

        return Ok(categoriaResult);
    }

    [HttpDelete]
    public IActionResult ApagarCategoria(int id)
    {
        var result = _categoriaInterface.ApagarCategoria(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosCategoria(int id, CategoriaDto categoria)
    {
        var result = _categoriaInterface.AlterarDadoscategoria(id, categoria);

        return Ok(result);
    }
}
