using API_Cadastro.Data;
using API_Cadastro.Logging;
using Microsoft.Build.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Cadastro.Services;
using API_Cadastro.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUserService, UserServiceImplementations>();


//Adiciona o proprio serviço de logs
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));


builder.Services.AddRazorPages();

var app = builder.Build();


//Cria as tabelas caso não exista
app.Services.CreateScope().ServiceProvider.GetRequiredService<UserDbContext>().Database.EnsureCreated();
//app.Services.CreateScope().ServiceProvider.GetRequiredService<UserDbContext>().Database.Migrate();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}"
    pattern: "{controller=User}/{action=Index}");


app.Run();







