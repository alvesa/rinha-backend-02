using Microsoft.EntityFrameworkCore;
using Repositories;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;
using rinha_backend_api.Repositories;
using rinha_backend_api.Services;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAccountService, ClienteService>();
builder.Services.AddScoped<IExtratoServico, ExtratoServico>();
builder.Services.AddScoped<IClienteRepositorio, ClientRepositorio>();
// builder.Services.AddSingleton<RinhaContexto>();
builder.Services.AddScoped<ITransacaoRespositorio, TransacaoRespositorio>();
builder.Services.AddDbContext<RinhaContexto>(x => x.UseNpgsql(@"Host=172.17.0.1;Database=rinha;Username=admin;Password=123"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
