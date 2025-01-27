using AutoMapper;
using projecto_autismo.Application.Dto;
using projecto_autismo.Application.Entity;
using projecto_autismo.Domain;

namespace projecto_autismo.InfraStructure.Mapper
{
    public class MappeadorProjecto:Profile
    {
        public MappeadorProjecto()
        {
            CreateMap<AlunoDto, AlunoEntity>();
            CreateMap<AlunoEntity, AlunoDto>();

            CreateMap<BibliotecaVirtualDto, BibliotecaVirtualEntity>();
            CreateMap<BibliotecaVirtualEntity, BibliotecaVirtualDto>();

            CreateMap<EncarregadoDto, EncarregadoEntity>();
            CreateMap<EncarregadoEntity, EncarregadoDto>();

            CreateMap<DisciplinaDto, DisciplinaEntity>();
            CreateMap<DisciplinaEntity, DisciplinaDto>();

            CreateMap<CategoriaDto, CategoriaEntity>();
            CreateMap<CategoriaEntity, CategoriaDto>();

            CreateMap<FuncionarioDto, FuncionarioEntity>();
            CreateMap<FuncionarioEntity, FuncionarioDto>();

            CreateMap<EncarregadoDto, EncarregadoEntity>();
            CreateMap<EncarregadoEntity, EncarregadoDto>();

            CreateMap<MatriculaDto, MatriculaEntity>();
            CreateMap<MatriculaEntity, MatriculaDto>();

            CreateMap<NotaDto, NotaEntity>();
            CreateMap<NotaEntity, NotaDto>();

            CreateMap<TesteDto, TesteEntity>();
            CreateMap<TesteEntity, TesteDto>();

            CreateMap<TurmaDto, TurmaEntity>();
            CreateMap<TurmaEntity, TurmaDto>();

            CreateMap<VitrineDto, VitrineEntity>();
            CreateMap<VitrineEntity, VitrineDto>();

            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<CargoDto, CargoEntity>();
            CreateMap<CargoEntity, CargoDto>();
        }
    }
}
