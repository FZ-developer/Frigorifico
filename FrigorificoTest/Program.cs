using Contracts.Repositories;
using Contracts.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<FrigorificoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FrigorificoSQL")));

builder.Services.AddScoped<IFrigorificoRepository, FrigorificoRepository>();
builder.Services.AddScoped<IFrigorificoService, FrigorificoService>();

builder.Services.AddScoped<ICampoRepository, CampoRepository>();
builder.Services.AddScoped<ICampoService, CampoService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddScoped<IFacturaCompraRepository, FacturaCompraRepository>();
builder.Services.AddScoped<IFacturaCompraService, FacturaCompraService>();

builder.Services.AddScoped<IFacturaVentaRepository, FacturaVentaRepository>();
builder.Services.AddScoped<IFacturaVentaService, FacturaVentaService>();

builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
