using Microsoft.EntityFrameworkCore;
using StockApi.Data;

var builder = WebApplication.CreateBuilder(args);

// --- Servicios ---
builder.Services.AddControllers();
builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))
    ));

builder.Services.AddCors();

var app = builder.Build();

// --- Middleware ---
app.UseRouting(); // <- Importante para enrutar correctamente
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

// --- Rutas ---
app.MapControllers();

app.Run();
