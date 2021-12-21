using API_Cadastro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using API_Cadastro.Migrations;


var builder = WebApplication.CreateBuilder(args);

//Logs
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//Migra��o
//using (var scope = app.Services.CreateScope())
/*
using (var scope = builder.Build().Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<UserDbContext>().Database.Migrate();
}
*/
/*
var scope = builder.Build().Services.CreateScope();
scope.ServiceProvider.GetRequiredService<UserDbContext>().Database.Migrate();
*/

//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



