
using fiap.core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = "Server=(localdb)\\mssqllocaldb;Database=fiap-musicas;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<MusicaContext>(o => o.UseSqlServer(connection));

builder.Services.AddControllers();


var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();
