var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();

var app = builder.Build();


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
    defaults: new {Controller = "Home", Action = "Index" },
    pattern: "{controller}/{action}/{id?}"
);
//app.MapControllerRoute(
//    name: "default",
//   // pattern: "{controller}/{action}/{id?}"
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//);





//app.MapGet("/", 

//    () => "Boa noite agora que tem energia"

//    );
//app.MapGet("/teste", () => "teste");


app.Run();





