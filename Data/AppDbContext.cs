using hostello.Models;
using Microsoft.EntityFrameworkCore;

namespace hostello.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<TipoAcomodacao> TiposAcomodacoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Acomodacao> Acomodacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Categoria>().HasData(
            new Categoria{IdCategoria = 1, Nome = "Suíte"},
            new Categoria{IdCategoria = 2, Nome = "Internet"},
            new Categoria{IdCategoria = 3, Nome = "Estacionamento"},
            new Categoria{IdCategoria = 4, Nome = "ArCondicionado"},
            new Categoria{IdCategoria = 5, Nome = "Elevador"},
            new Categoria{IdCategoria = 6, Nome = "TV"},
            new Categoria{IdCategoria = 7, Nome = "Frigobar"},
            new Categoria{IdCategoria = 8, Nome = "BeiraMar"}
        );
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}