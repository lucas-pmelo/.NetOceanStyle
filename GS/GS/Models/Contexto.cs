using Microsoft.EntityFrameworkCore;

namespace GS.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Inspetor> Inspetores { get; set; }
    public DbSet<InspetoresVistorias> InspetoresVistorias { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Vistoria> Vistorias { get; set; }
}
