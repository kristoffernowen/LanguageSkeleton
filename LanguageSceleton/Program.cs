using Application;
using AutoMapper;
using Data;
using Data.SeedData;
using LanguageSkeleton.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("### ACTUAL CONNECTION STRING ###");
Console.WriteLine(builder.Configuration.GetConnectionString("Sql"));
Console.WriteLine("CONN via indexer: " + builder.Configuration["ConnectionStrings:Sql"]);
Console.WriteLine("################################");

builder.Services.AddDataExtensions(builder.Configuration);
builder.Services.AddApplicationExtensions(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()!)
            .AllowAnyMethod()
            .WithHeaders("Content-Type", "x-api-key");
    });
});

var app = builder.Build();

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SqlContext>();
    var mapper = services.GetRequiredService<IMapper>();

    // Let's try ensureCreated instead of Migrate for now, since it seems Migrations might not be working correctly in the current setup on azure. It's just for demo.
    context.Database.EnsureCreated();

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

app.UseRouting();

app.UseCors("FrontendPolicy");

app.UseWhen(
    ctx => ctx.Request.Path.StartsWithSegments("/api"),
    appBuilder => appBuilder.UseApiKeyValidation()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
