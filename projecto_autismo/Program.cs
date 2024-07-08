using projecto_autismo.Application.Services;
using projecto_autismo.InfraStructure.Mapper;
using projecto_autismo.InfraStructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappeadorProjecto));

builder.Services.AddTransient<IAluno, AlunoRepository>();
builder.Services.AddTransient<IEncarregado, EncarregadoRepository>();
builder.Services.AddTransient<IBiblioteca, BibliotecaRepository>();
builder.Services.AddTransient<ICategoria, CategoriaRepository>();
builder.Services.AddTransient<IDisciplina, DisciplinaRepository>();
builder.Services.AddTransient<IFuncionario, FuncionarioRepository>();
builder.Services.AddTransient<IMatricula, MatriculaRepository>();
builder.Services.AddTransient<INota, NotaRepository>();
builder.Services.AddTransient<ITeste, TesteRepository>();
builder.Services.AddTransient<ITurma, TurmaRepository>();
builder.Services.AddTransient<IVitrine, VitrineRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
