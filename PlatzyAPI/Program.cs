using Microsoft.EntityFrameworkCore;
using PlatzyAPI.Middleware;
using PlatzyAPI.Models;
using PlatzyAPI.Services;
using PlatzyAPI.Services.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TareasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("cnTareas")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //Los servicios son las dependencias

//Inyeccion de dependencia con interface
//builder.Services.AddScoped<IHelloWorldServices, HellowWorldServices>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

//Inyeccion de dependencia de clase 
builder.Services.AddScoped<IHelloWorldServices>(p => new HellowWorldServices());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //MiddleWare
    app.UseSwagger();
    app.UseSwaggerUI();
}

//MiddleWare
app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseTimeMiddleware();

//app.UseWelcomePage();

app.MapControllers();

app.Run();
