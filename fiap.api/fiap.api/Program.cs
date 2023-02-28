
using fiap.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(s => {
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "fiap.api", Version = "v1" });

});


builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls=true);



builder.Services.AddCors(
    options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));


var connection = "Server=(localdb)\\mssqllocaldb;Database=fiap-musicas;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<MusicaContext>(o => o.UseSqlServer(connection));

builder.Services.AddControllers(
    config => {
        config.RespectBrowserAcceptHeader = true;
    }).AddXmlDataContractSerializerFormatters();


//builder.Services.AddApiVersioning();
//builder.Services.AddApiVersioning(setup => { setup.DefaultApiVersion = new ApiVersion(1, 0); setup.AssumeDefaultVersionWhenUnspecified = true; setup.ReportApiVersions = true; }


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "fiap.api v1"));

app.UseCors("AllowAll");
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();
