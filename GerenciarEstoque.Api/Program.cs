using GerenciarEstoque.Aplicacao;
using GerenciarEstoque.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

// Add services to the container.

builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IProdutoAplicacao, ProdutoAplicacao>();
builder.Services.AddScoped<ICategoriaAplicacao, CategoriaAplicacao>();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

builder.Services.AddControllers();

builder.Services.AddDbContext<GerenciarEstoqueContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();