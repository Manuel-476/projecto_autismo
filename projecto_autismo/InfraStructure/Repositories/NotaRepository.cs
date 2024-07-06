using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projecto_autismo.Application.Entity;
using projecto_autismo.Application.Services;
using projecto_autismo.Domain;
using projecto_autismo.InfraStructure.DataBase;

namespace projecto_autismo.InfraStructure.Repositories;

public class NotaRepository : INota
{
    private IMapper _mapper;

    public NotaRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public bool AlterarDadosNota(int id, NotaDto nota)
    {
        var conector = new DbConnection();
        try
        {
            var newNota = _mapper.Map<NotaEntity>(nota);
            var oldNota = conector.nota.Where(nota => nota.id == id).First();

            oldNota.nota1 = oldNota.nota1;
            oldNota.nota2 = newNota.nota2;
            oldNota.nota3 = newNota.nota3;
            oldNota.disciplinaId = newNota.disciplinaId;

            conector.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao alterar dados do matricula: {ex.Message}");
        }
    }

    public bool ApagarNota(int id)
    {
        using var conector = new DbConnection();
        try
        {
            conector.nota.Where(nota => nota.id == id).ExecuteDelete();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception($"Erro ao apagar Nota: {ex.Message}");
        }
    }

        public List<NotaDto> ListarNotas()
        {
            using var conector = new DbConnection();
            try
            {
                var notas = conector.nota.ToList();

                var result = _mapper.Map<List<NotaDto>>(notas);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Notas: {ex.Message}");
            }
        }

        public NotaDto ObterNotaPeloId(int id)
        {
            var conector = new DbConnection();
            try
            {
                var nota = this.ListarNotas().Where(mat => mat.id == id).First();

                return nota;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pegar id do Nota: {ex.Message}");
            }
        }

    public NotaDto SalvarNota(NotaDto nota)
    {
        var conector = new DbConnection();

        try
        {
            var notaEntity = _mapper.Map<NotaEntity>(nota);

            conector.nota.Add(notaEntity);

            conector.SaveChanges();

            var result = _mapper.Map<NotaDto>(notaEntity);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro ao salvar nota: {ex.Message}");
        }
    }
}
