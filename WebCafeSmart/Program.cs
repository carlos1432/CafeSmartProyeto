using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicion Contexto de base de datos
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CAFESMARTConnStr")));

// Adicion de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Adicion servicios
builder.Services.AddScoped<CafeService>();
builder.Services.AddScoped<CaracteristicaService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<TiposService>();
builder.Services.AddScoped<UsuarioService>();

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
