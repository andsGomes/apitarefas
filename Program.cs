using Microsoft.EntityFrameworkCore;
using TarefasAPI.Application.Mapping;
using TarefasAPI.Context;
using TarefasAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(DomainDtoMapping));

builder.Services.AddScoped<ITarefasRepositories, TarefasServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<TarefasDbContext>(op => op.UseMySql(connection, new MySqlServerVersion(new Version(8, 2, 0))));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");


app.MapControllers();

app.Run();
