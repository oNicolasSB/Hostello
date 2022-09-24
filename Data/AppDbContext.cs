using hostello.Models;
using Microsoft.EntityFrameworkCore;

namespace hostello.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<TipoAcomodacao> TiposAcomodacoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<ItemReserva> ItensReserva { get; set; }
    public DbSet<Acomodacao> Acomodacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Acomodacao>().HasKey(ip => new{ ip.FkTipoAcomodacao});
        mb.Entity<Acomodacao>().HasKey(ip => new{ ip.FkEstabelecimento});
        mb.Entity<Admin>().HasKey(ip => new{ ip.FkUsuario});
        mb.Entity<Avaliacao>().HasKey(ip => new{ ip.FkCliente});
        mb.Entity<Avaliacao>().HasKey(ip => new{ ip.FkAcomodacao});
        mb.Entity<Cliente>().HasKey(ip => new{ ip.FkEndereco});
        mb.Entity<Cliente>().HasKey(ip => new{ ip.FkUsuario});
        mb.Entity<Contato>().HasKey(ip => new{ ip.FkEstabelecimento});
        mb.Entity<Estabelecimento>().HasKey(ip => new{ ip.FkEndereco});
        mb.Entity<ItemReserva>().HasKey(ip => new{ ip.FkAcomodacao});
        mb.Entity<ItemReserva>().HasKey(ip => new{ ip.FkReserva});
        mb.Entity<Reserva>().HasKey(ip => new{ ip.FkCliente});
        mb.Entity<Responsavel>().HasKey(ip => new{ ip.FkUsuario});
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}