using DomainLibrary.Interfaces;
using EFDataAccessLibrary;
using EFDataAccessLibrary.Repositories;
using EFDataAccessLibrary.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.







builder.Services.AddDbContext<BookingContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//adding the repositories

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IRouteRepository,RouteRepository>();
builder.Services.AddTransient<IStationRepository,StationRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainTicketsApp", Version = "v1" }); });




//Adding the unit of work to the dependency injection container
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
