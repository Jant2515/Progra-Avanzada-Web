using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzadaWeb.Models;
using Proyecto_PrograAvanzadaWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VerduleriaContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("VerduleriaContext")));

//Tipos de Servicios
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

//Sesiones

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opciones =>
{
    opciones.IdleTimeout = TimeSpan.FromHours(2);
    opciones.Cookie.HttpOnly = true;
    opciones.Cookie.IsEssential = true;
});


//Servios del Proyecto
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IMarcaService, MarcaService>();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



app.Run();
