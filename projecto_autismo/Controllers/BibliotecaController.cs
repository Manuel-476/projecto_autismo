using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.Controllers;
[Route("api/Biblioteca_Virtual")]
[ApiController]
public class BibliotecaController : ControllerBase
{
    private IBiblioteca _mediaInterface;
    public BibliotecaController(IBiblioteca mediaInterface)
    {
        _mediaInterface = mediaInterface;
    }

    [HttpPost]
    public IActionResult SalvarMedia([FromForm] BibliotecaVirtualDto mediaV)
    {
            var conector = new DbConnection();

            Console.WriteLine($"{mediaV.mediaFile.FileName}");

            var filePath = Path.Combine("Storage", mediaV.mediaFile.FileName);


            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            mediaV.mediaFile.CopyTo(fileStream);

            var media = new BibliotecaVirtualEntity()
            {
                categoriaId = mediaV.categoriaId,
                funcionarioId = mediaV.funcionarioId,
                descricao = mediaV.descricao,
                endereco = mediaV.endereco,
                titulo = mediaV.titulo,
                media = filePath
            };

            conector.bVirtual.Add(media);
            conector.SaveChanges();
  
        return Ok(media);
    }

    [HttpGet]
    public IActionResult ListarMedia()
    {
        var medias = _mediaInterface.ListarMedias();

        return Ok(medias);
    }

    [HttpGet("{id}")]
    public IActionResult ObterMediapeloId(int id)
    {
        var mediaResult = _mediaInterface.ObterMediaPeloId(id);

        return Ok(mediaResult);
    }

    [HttpGet]
    [Route("Download/{id}")]
    public IActionResult DownloadMedia(int id)
    {
        var dataBytes = _mediaInterface.GetDownloadMedia(id);

        try
        {
            return File(dataBytes as Byte[], "image/jpg");
         
            
        }
        catch 
        {
            return File(dataBytes as Byte[], "video/mp4"); 
        }
     
    }


    [HttpDelete]
    public IActionResult ApagarMedia(int id)
    {
        var result = _mediaInterface.ApagarMedia(id);

        return Ok(result);
    }

    [HttpPut]
    public IActionResult AlterarDadosMedia(int id, BibliotecaVirtualDto media)
    {
        var result = _mediaInterface.AlterarDadosMedia(id, media);

        return Ok(result);
    }
}
