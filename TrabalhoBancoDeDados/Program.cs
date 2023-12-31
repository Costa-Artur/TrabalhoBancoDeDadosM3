using Microsoft.EntityFrameworkCore;
using TrabalhoBancoDeDados.api.DbContexts;
using TrabalhoBancoDeDados.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnivaliRepository, UnivaliRepository>();

builder.Services.AddDbContext<UnivaliContext>(options =>
{
    options
    .UseNpgsql("Host=localhost;Port=5432;Database=TrabalhoBD;Username=postgres;Password=pass123;Include Error Detail=true");
}
);

// Add services to the container.

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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
