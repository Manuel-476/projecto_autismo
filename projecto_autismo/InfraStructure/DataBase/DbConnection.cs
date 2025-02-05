using Microsoft.EntityFrameworkCore;
using projecto_autismo.Domain;

namespace projecto_autismo.InfraStructure.DataBase
{
    public class DbConnection:DbContext
    {
        public DbSet<AlunoEntity> aluno {  get; set; }
        public DbSet<BibliotecaVirtualEntity> bVirtual { get; set; }
        public DbSet<CategoriaEntity> categoria { get; set; }
        public DbSet<DisciplinaEntity> disciplina { get; set; }
        public DbSet<EncarregadoEntity> encarregado { get; set; }
        public DbSet<FuncionarioEntity> funcionario { get; set; }
        public DbSet<MatriculaEntity> matricula { get; set; }
        public DbSet<NotaEntity> nota { get; set; }
        public DbSet<TesteEntity> teste { get; set; }
        public DbSet<TurmaEntity> turma { get; set; }
        public DbSet<VitrineEntity> vitrine { get; set; }
        public DbSet<UserEntity> user { get; set; }
        public DbSet<CargoEntity> cargo { get; set; }
        public DbSet<AnoLectivoEntity> anoLectivo { get; set; }
        public DbSet<TrimestreEntity> trimestre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;user=root;database=projecto_autismo;password=";
            MySqlServerVersion version = new MySqlServerVersion(new Version(10,4, 24));
            optionsBuilder.UseMySql(connectionString, version);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AlunoEntity>()
            //            .HasMany(al => al.encarregados)
            //            .WithMany(en => en.alunos);

            //modelBuilder.Entity<MatriculaEntity>()
            //            .HasOne(mat => mat.aluno)
            //            .WithOne(al => al.matricula)
            //            .HasForeignKey<MatriculaEntity>(mat => mat.alunoId);

           /* modelBuilder.Entity<FuncionarioEntity>()
                        .HasMany(fun => fun.virtuais)
                        .WithOne(vir => vir.funcionario)
                        .HasForeignKey(vir => vir.funcionarioId);*/

            modelBuilder.Entity<FuncionarioEntity>()
                        .HasMany(fun => fun.vitrines)
                        .WithOne(vit => vit.funcionario)
                        .HasForeignKey(vit => vit.funcionarioId);

          /*  modelBuilder.Entity<BibliotecaVirtualEntity>()
                        .HasOne(vir => vir.categoria)
                        .WithMany(c => c.virtuais)
                        .HasForeignKey(vir => vir.categoriaId);*/

            //modelBuilder.Entity<DisciplinaEntity>()
            //            .HasMany(disc => disc.turmas)
            //            .WithMany(t => t.disciplinas);

            //modelBuilder.Entity<DisciplinaEntity>()
            //.HasMany(disc => disc.notas)
            //.WithOne(n => n.disciplina)
            //.HasForeignKey(n => n.disciplinaId);

        }
    }
}
