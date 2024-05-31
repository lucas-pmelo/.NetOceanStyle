using GS.Models;
using GS.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseOracle(
        "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))\n(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM97707;Password=220600;");
});

builder.Services.AddTransient<ICidadeRepository, CidadeRepository>();
builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<IInspetorRepository, InspetorRepository>();
builder.Services.AddTransient<IInspetoresVistoriasRepository, InspetoresVistoriasRepository>();
builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddTransient<IVistoriaRepository, VistoriaRepository>();


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