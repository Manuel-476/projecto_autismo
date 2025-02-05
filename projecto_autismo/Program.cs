using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using projecto_autismo.Application.Services;
using projecto_autismo.InfraStructure.Mapper;
using projecto_autismo.InfraStructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with Jwt",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id="Bearer",
                    Type= ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
      });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Example API",
        Version = "v1",
        Description = "An example of an ASP.NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Email = "example@example.com",
            Url = new Uri("https://example.com/contact"),
        },
    });
});

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
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<IAnoLectivo, AnoLectivoRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

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
