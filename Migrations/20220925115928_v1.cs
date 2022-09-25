using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Pais = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "TiposAcomodacoes",
                columns: table => new
                {
                    IdTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAcomodacao = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAcomodacoes", x => x.IdTipoAcomodacao);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sexo = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    IdResponsavel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.IdResponsavel);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaSaida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorReserva = table.Column<double>(type: "REAL", nullable: false),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    IdEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    TelefoneFixo = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    MediaAvaliacao = table.Column<double>(type: "REAL", nullable: false),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelIdResponsavel = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.IdEstabelecimento);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Responsaveis_ResponsavelIdResponsavel",
                        column: x => x.ResponsavelIdResponsavel,
                        principalTable: "Responsaveis",
                        principalColumn: "IdResponsavel");
                });

            migrationBuilder.CreateTable(
                name: "Acomodacoes",
                columns: table => new
                {
                    IdAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaAvaliacaoQuarto = table.Column<double>(type: "REAL", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMin = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMax = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDiaria = table.Column<double>(type: "REAL", nullable: false),
                    FkTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acomodacoes", x => x.IdAcomodacao);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_TiposAcomodacoes_FkTipoAcomodacao",
                        column: x => x.FkTipoAcomodacao,
                        principalTable: "TiposAcomodacoes",
                        principalColumn: "IdTipoAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAvaliacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NotaAvaliacao = table.Column<double>(type: "REAL", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "IdAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensReserva",
                columns: table => new
                {
                    IdItemReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    FkReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensReserva", x => x.IdItemReserva);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "IdAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Reservas_FkReserva",
                        column: x => x.FkReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkEstabelecimento",
                table: "Acomodacoes",
                column: "FkEstabelecimento");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkTipoAcomodacao",
                table: "Acomodacoes",
                column: "FkTipoAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_FkUsuario",
                table: "Admins",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkAcomodacao",
                table: "Avaliacoes",
                column: "FkAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkCliente",
                table: "Avaliacoes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkEndereco",
                table: "Clientes",
                column: "FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkUsuario",
                table: "Clientes",
                column: "FkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_FkEstabelecimento",
                table: "Contatos",
                column: "FkEstabelecimento");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_FkEndereco",
                table: "Estabelecimentos",
                column: "FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_ResponsavelIdResponsavel",
                table: "Estabelecimentos",
                column: "ResponsavelIdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_FkAcomodacao",
                table: "ItensReserva",
                column: "FkAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_FkReserva",
                table: "ItensReserva",
                column: "FkReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkCliente",
                table: "Reservas",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_FkUsuario",
                table: "Responsaveis",
                column: "FkUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "ItensReserva");

            migrationBuilder.DropTable(
                name: "Acomodacoes");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "TiposAcomodacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
