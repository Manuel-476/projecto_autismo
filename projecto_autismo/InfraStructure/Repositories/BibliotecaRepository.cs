using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace projecto_autismo.InfraStructure.Repositories;

public class BibliotecaRepository : IBiblioteca
{
    private IMapper _mapper;
    public BibliotecaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadosMedia(int id, BibliotecaVirtualDto bVirtual)
    {
        var conector = new DbConnection();
        try
        {
            var newVirtual = _mapper.Map<BibliotecaVirtualEntity>(bVirtual);
            var oldVirtual = conector.bVirtual.Where(en => en.id == id).First();

            oldVirtual.media = newVirtual.media;
            oldVirtual.categoriaId = newVirtual.categoriaId;
            oldVirtual.funcionarioId = newVirtual.funcionarioId;
            oldVirtual.descricao = newVirtual.descricao;
            oldVirtual.endereco = newVirtual.endereco;
            oldVirtual.titulo = newVirtual.titulo;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do Media: {ex.Message}");
        }
    }

    public bool ApagarMedia(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.bVirtual.Where(vir => vir.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao apagar media: {ex.Message}");
        }
    }

    public List<BibliotecaVirtualDto> ListarMedias()
    {

        var conector = new DbConnection();

        try
        {
            var media = conector.bVirtual.ToList();

            var result = _mapper.Map<List<BibliotecaVirtualDto>>(media);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao fazer listagem da medias apartir do Id: {ex.Message}");
        }
    }

    public object GetDownloadMedia(int id) 
    {
        var conector = new DbConnection();

        try
        {
            var media = conector.bVirtual.Find(id);

            var dataBytes = System.IO.File.ReadAllBytes(media.media);

            return dataBytes;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao fazer download da media apartir do Id: {ex.Message}");
        }
    }

    public BibliotecaVirtualDto ObterMediaPeloId(int id)
    {
        var conector =new DbConnection();

        try
        {
            var media = conector.bVirtual.Find(id);

            var dataBytes = System.IO.File.ReadAllBytes(media.media);

            BibliotecaVirtualDto result = _mapper.Map<BibliotecaVirtualDto>(media);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao obter a media apartir do Id: {ex.Message}");
        }

    }

    public BibliotecaVirtualDto SalvarMedia(BibliotecaVirtualDto bVirtual)
    {
        var conector = new DbConnection();

        try
        {
            Console.WriteLine($"{bVirtual.mediaFile.FileName}");
            var filePath = Path.Combine("Storage", bVirtual.mediaFile.FileName);


            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            bVirtual.media.CopyTo(fileStream);

            var media = new BibliotecaVirtualEntity()
            {
                categoriaId = bVirtual.categoriaId,
                funcionarioId = bVirtual.funcionarioId,
                endereco = bVirtual.endereco,
                titulo = bVirtual.titulo,
                media = filePath
            };

            conector.bVirtual.Add(media);
            return bVirtual;
        }
        catch(Exception ex) 
        {
            throw new Exception($"Erro a o salvar media: {ex.Message}");
        }
    }
}
