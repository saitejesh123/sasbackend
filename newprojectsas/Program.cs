using Microsoft.EntityFrameworkCore;
using newprojectsas.Data;
using newprojectsas.Repository;
using newprojectsas.Repository.stdinfoRepository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<newprojectsasContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IstdinfoRepository, stdinfoRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Serilog logger
Log.Logger = new LoggerConfiguration().WriteTo.File("D:\\newproj\\mylog.log", rollingInterval: RollingInterval.Day).CreateLogger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS middleware
app.UseCors("AllowAngularOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
