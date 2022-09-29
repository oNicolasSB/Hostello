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
    public DbSet<ItemReserva> ItensReserva { get; set; }
    public DbSet<Acomodacao> Acomodacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}