using hostello.Models;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

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
        mb.Entity<Endereco>().HasData(
            new Endereco{IdEndereco = 1, Logradouro = "Rua dos bobos", Bairro = "Bairro dos bobos", Numero = "0", Complemento = "apt 404", Cep = "29360-000", Cidade="Castelo", Estado= "Espirito Santo", Pais = "Brasil"}
        );
        mb.Entity<Administrador>().HasData(
            new Administrador{IdUsuario = 1, Nome = "Nicolas", Cpf = "111.111.111-11", Email = "nicolasbassini@hotmail.com", Senha = HashPassword("senhanicolas", 10), Telefone = "+5528999752520", DataNascimento = new DateTime(2003, 08, 06), Sexo = EnumSexo.Masculino
            }
        );
        mb.Entity<Responsavel>().HasData(
            new Responsavel{
                IdUsuario = 2, Nome = "Dono Empresa", Cpf = "222.222.222-22", Email = "dono@empresa.com", Senha = HashPassword("123123", 10), Telefone = "+5528999999999", DataNascimento = new DateTime(2000, 01, 01), Sexo = EnumSexo.Feminino, CNPJ = "12312312312312", NomeFantasia = "Empresa Fantasia", Celular = "+5528999999998", RazaoSocial = "Empresa Corporation", FkEndereco = 1
            }
        );
        mb.Entity<TipoAcomodacao>().HasData(
            new TipoAcomodacao{IdTipoAcomodacao = 1, NomeTipoAcomodacao = "Quarto"},
            new TipoAcomodacao{IdTipoAcomodacao = 2, NomeTipoAcomodacao = "Pousada"}
        );

    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}