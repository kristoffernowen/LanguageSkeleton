using Application;
using AutoMapper;
using Data;
using Data.SeedData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataExtensions(builder.Configuration);
builder.Services.AddApplicationExtensions(builder.Configuration);

var app = builder.Build();

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SqlContext>();
    var mapper = services.GetRequiredService<IMapper>();

    // Apply migrations automatically
    context.Database.Migrate();

    // Seed data if database is empty
    DatabaseSeeder.SeedVerbs(context, mapper);
    DatabaseSeeder.SeedNouns(context, mapper);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




// !!!!!!!!!!!!!!!!!!!! fix cors

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());    
app.UseAuthorization();

app.MapControllers();

app.Run();
