using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.dotnet

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(origin => true) // allow any origin
                                                       //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                   .AllowCredentials()); // allow credentials
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
