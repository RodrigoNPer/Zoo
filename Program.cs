using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do servidor para rodar na porta 5050
builder.WebHost.UseUrls("http://localhost:5050");

// Configuração do DbContext com a string de conexão do appsettings.json
builder.Services.AddDbContext<ZooContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona suporte a controllers da API
builder.Services.AddControllers();

// Configuração de CORS para permitir requisições do frontend React
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Permite apenas o frontend React
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuração do pipeline de middleware
app.UseRouting();
app.UseCors(); // Habilita o CORS antes do Authorization
app.UseAuthorization();
app.MapControllers();

app.Run();