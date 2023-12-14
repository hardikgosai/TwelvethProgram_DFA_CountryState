using Getri_DFA_CountryState.EntityFramework;
using Getri_DFA_CountryState.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<GetricountryStateDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryStateConnection")));
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IStateReposiory, StateRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
