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
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Admin>().HasKey(ip => new{ ip.FkUsuario}); // protocolação de chave composta em ItemPedido
        mb.Entity<Responsavel>().HasKey(ip => new{ ip.FkUsuario});
        mb.Entity<Cliente>().HasKey(ip => new{ ip.FkUsuario});
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}