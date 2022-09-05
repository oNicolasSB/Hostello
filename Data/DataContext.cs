using Microsoft.EntityFrameworkCore;
using hostello.Models;

namespace hostello.Data;

public class DataContext : DbContext
{
    public DbSet<Acomodacao> Acomodacoes { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<ItemReserva> ItensReserva { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<TipoAcomodacao> TiposAcomodacoes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Acomodacao>().HasKey(ip => new{ ip.FkTipoAcomodacao});
        mb.Entity<Avaliacao>().HasKey(ip => new{ ip.FkCliente});
        mb.Entity<Avaliacao>().HasKey(ip => new{ ip.FkAcomodacao});
        mb.Entity<Cliente>().HasKey(ip => new{ ip.FkEndereco});
        mb.Entity<Estabelecimento>().HasKey(ip => new{ ip.FkEndereco});
        mb.Entity<ItemReserva>().HasKey(ip => new{ ip.FkAcomodacao});
        mb.Entity<ItemReserva>().HasKey(ip => new{ ip.FkReserva});
        mb.Entity<Reserva>().HasKey(ip => new{ ip.FkCliente});
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}