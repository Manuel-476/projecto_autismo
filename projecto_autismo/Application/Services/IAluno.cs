using projecto_autismo.Application.Entity;

namespace projecto_autismo.Application.Services
{
    public interface IAluno
    {
        public AlunoDto SalvarAluno(AlunoDto aluno);
        public List<AlunoDto> ListarAlunos();
        public AlunoDto ObterAlunoPeloId(int id);
        public bool AlterarDadosAluno(int id, AlunoDto aluno);
        public bool ApagarAluno(int id);


    }
}
