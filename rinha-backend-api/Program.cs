using Repositories;
using rinha_backend_api.IoC.Repositories;
using rinha_backend_api.IoC.Services;
using rinha_backend_api.Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAccountService, ClienteService>();
builder.Services.AddScoped<IExtratoRepository, ExtratoRepository>();
builder.Services.AddSingleton<AccountContext>();
builder.Services.AddScoped<ITransacaoRespository, TransacaoRespository>();

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
