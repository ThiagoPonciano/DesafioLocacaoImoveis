using DesafioLocacaoImoveis.Api.Data;
using DesafioLocacaoImoveis.Api.Domain.Services;
using DesafioLocacaoImoveis.Api.Repositories;
using DesafioLocacaoImoveis.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ViaCepService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddDbContext<LocacaoImoveisDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DataBase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

builder.Services.AddScoped<ILocacaoImoveisRepositorie, ImoveisRepositorie>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
