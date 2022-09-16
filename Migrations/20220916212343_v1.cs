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
                name: "Estabelecimentos",
                columns: table => new
                {
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    TelefoneFixo = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    MediaAvaliacao = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.FkEndereco);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAdmin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.FkUsuario);
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
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.FkUsuario);
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
                    FkUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    IdResponsavel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.FkUsuario);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Usuarios_FkUsuario",
                        column: x => x.FkUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acomodacoes",
                columns: table => new
                {
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaAvaliacaoQuarto = table.Column<double>(type: "REAL", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMin = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDiaria = table.Column<double>(type: "REAL", nullable: false),
                    FkTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acomodacoes", x => x.FkEstabelecimento);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "FkEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_TiposAcomodacoes_FkTipoAcomodacao",
                        column: x => x.FkTipoAcomodacao,
                        principalTable: "TiposAcomodacoes",
                        principalColumn: "IdTipoAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaSaida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorReserva = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.FkCliente);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "FkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoResponsavel",
                columns: table => new
                {
                    EstabelecimentosFkEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsaveisFkUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoResponsavel", x => new { x.EstabelecimentosFkEndereco, x.ResponsaveisFkUsuario });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoResponsavel_Estabelecimentos_EstabelecimentosFkEndereco",
                        column: x => x.EstabelecimentosFkEndereco,
                        principalTable: "Estabelecimentos",
                        principalColumn: "FkEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoResponsavel_Responsaveis_ResponsaveisFkUsuario",
                        column: x => x.ResponsaveisFkUsuario,
                        principalTable: "Responsaveis",
                        principalColumn: "FkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NotaAvaliacao = table.Column<double>(type: "REAL", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.FkAcomodacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "FkEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "FkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensReserva",
                columns: table => new
                {
                    FkReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    IdItemReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensReserva", x => x.FkReserva);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "FkEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Reservas_FkReserva",
                        column: x => x.FkReserva,
                        principalTable: "Reservas",
                        principalColumn: "FkCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkTipoAcomodacao",
                table: "Acomodacoes",
                column: "FkTipoAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkCliente",
                table: "Avaliacoes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkEndereco",
                table: "Clientes",
                column: "FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoResponsavel_ResponsaveisFkUsuario",
                table: "EstabelecimentoResponsavel",
                column: "ResponsaveisFkUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_FkAcomodacao",
                table: "ItensReserva",
                column: "FkAcomodacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "EstabelecimentoResponsavel");

            migrationBuilder.DropTable(
                name: "ItensReserva");

            migrationBuilder.DropTable(
                name: "Responsaveis");

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
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
