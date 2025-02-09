using Microsoft.EntityFrameworkCore;
using MeuProjetoBackend.Data;
using Microsoft.OpenApi.Models;
using MeuProjetoBackend.Services;
using MeuProjetoBackend.Repositories;
using MeuProjetoBackend.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MeuProjetoBackend.Models;

namespace MeuProjetoBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
    options.ListenAnyIP(8080);
    options.ListenAnyIP(5207); 
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddControllersWithViews();

builder.Services.AddValidatorsFromAssemblyContaining<ProdutoValidator>();
builder.Services.AddScoped<IValidator<Produto>, ProdutoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MeuProjetoBackend API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}/{id?}");


app.Run();

        }
    }
}
