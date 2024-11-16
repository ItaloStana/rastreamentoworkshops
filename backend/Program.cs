var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5500") // O endereço do seu frontend
              .AllowAnyHeader()  // Permite qualquer cabeçalho (header)
              .AllowAnyMethod(); // Permite qualquer método HTTP (GET, POST, PUT, DELETE, etc.)
    });
});

builder.Services.AddControllers();  // Adiciona suporte ao uso de controllers

var app = builder.Build();

// Usar o CORS configurado
app.UseCors("AllowFrontend"); // Habilita a política CORS chamada "AllowFrontend"

app.MapControllers();  // Mapear as rotas dos controllers

app.Run();  // Executa a aplicação
