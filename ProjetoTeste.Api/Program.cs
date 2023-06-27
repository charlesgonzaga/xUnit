using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Application.Clientes;
using ProjetoTeste.Application.Clientes.Cadastrar;
using ProjetoTeste.Application.Clientes.Listar;
using ProjetoTeste.Application.Produtos.Listar;
using ProjetoTeste.Infrastructure;
using ProjetoTeste.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MyContext") 
    ?? throw new InvalidOperationException("Connection string 'MyContext' not found.")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICadastrarCliente, CadastrarCliente>();
builder.Services.AddScoped<IListarCliente, ListarCliente>();
builder.Services.AddScoped<IListarProduto, ListarProduto>();
builder.Services.AddHttpClient<ListarProduto>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }