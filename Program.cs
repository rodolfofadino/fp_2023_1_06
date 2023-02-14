using fiap.Middlewares;
using fiap.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var connection = "Server=(localdb)\\mssqllocaldb;Database=fiap-musicas;Trusted_Connection=True;MultipleActiveResultSets=true";

builder.Services.AddDbContext<MusicaContext>(o => o.UseSqlServer(connection));


var app = builder.Build();


//app.UseMiddleware<MeuMiddleware>();

//app.UseMeuLogger();



if (!app.Environment.IsProduction())
    app.UseDeveloperExceptionPage();


app.UseStaticFiles();


//https://localhost:59148/home/index
app.UseRouting();

app.MapControllerRoute(
    name: "padraodoproduto",
    defaults: new { Controller = "Home", Action = "Detalhe" },
    pattern: "{categoria}/seuperfil/{idDoProduto}"
);

app.MapControllerRoute(
    name: "default",
    defaults: new { Controller = "Home", Action = "Index" },
    pattern: "{controller}/{action}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    // pattern: "{controller}/{action}/{id?}"
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();




#region 

//app.Use(async (context, next) =>
//{
//    var teste = 123;
//    await next();
//    var teste2 = 123;
//});

//app.Map("/admin", a =>
//{
//    a.Run(async context =>
//    {
//        await context.Response.WriteAsync("admin");
//    });
//});


//app.MapWhen(ctx => ctx.Request.Query.ContainsKey("valordaquery"),
//    a =>
//    {
//        a.Run(async context => await context.Response.WriteAsync("teste da query"));
//    }
//    );


//app.Use(async (context, next) =>
//{
//    var teste = 123;
//    await next();
//    var teste2 = 123;
//});

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Boa noite");

//});

#endregion



//app.MapGet("/", 

//    () => "Boa noite agora que tem energia"

//    );
//app.MapGet("/teste", () => "teste");







