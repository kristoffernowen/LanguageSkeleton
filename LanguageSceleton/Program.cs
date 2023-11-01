using Application;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataExtensions(builder.Configuration);
builder.Services.AddApplicationExtensions();

var app = builder.Build();

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
