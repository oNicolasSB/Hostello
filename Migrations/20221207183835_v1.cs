﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

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
                    NomeTipoAcomodacao = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
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
                    Nome = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Cliente_FkEndereco = table.Column<int>(type: "INTEGER", nullable: true),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    MediaAvaliacao = table.Column<double>(type: "REAL", nullable: true),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_Cliente_FkEndereco",
                        column: x => x.Cliente_FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                });

            migrationBuilder.CreateTable(
                name: "Acomodacoes",
                columns: table => new
                {
                    IdAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaAvaliacaoQuarto = table.Column<double>(type: "REAL", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMin = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMax = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDiaria = table.Column<double>(type: "REAL", nullable: false),
                    FkAdministrador = table.Column<int>(type: "INTEGER", nullable: true),
                    FkTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    FkResponsavel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acomodacoes", x => x.IdAcomodacao);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_TiposAcomodacoes_FkTipoAcomodacao",
                        column: x => x.FkTipoAcomodacao,
                        principalTable: "TiposAcomodacoes",
                        principalColumn: "IdTipoAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Usuarios_FkAdministrador",
                        column: x => x.FkAdministrador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Usuarios_FkResponsavel",
                        column: x => x.FkResponsavel,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    FkResponsavel = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelIdUsuario = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_Contatos_Usuarios_ResponsavelIdUsuario",
                        column: x => x.ResponsavelIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAvaliacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NotaAvaliacao = table.Column<double>(type: "REAL", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Aprovado = table.Column<bool>(type: "INTEGER", nullable: true),
                    FkAdministrador = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_Avaliacoes_Usuarios_FkAdministrador",
                        column: x => x.FkAdministrador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_FkCliente",
                        column: x => x.FkCliente,
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
                    PeriodoEstadia = table.Column<int>(type: "INTEGER", nullable: false),
                    QtdePessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorReserva = table.Column<double>(type: "REAL", nullable: false),
                    EstaPago = table.Column<bool>(type: "INTEGER", nullable: false),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "IdAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 1, "Suíte" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 2, "Internet" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 3, "Estacionamento" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 4, "ArCondicionado" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 5, "Elevador" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 6, "TV" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 7, "Frigobar" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 8, "BeiraMar" });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "IdEndereco", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero", "Pais" },
                values: new object[] { 1, "Bairro dos bobos", "29360-000", "Castelo", "apt 404", "Espirito Santo", "Rua dos bobos", "0", "Brasil" });

            migrationBuilder.InsertData(
                table: "TiposAcomodacoes",
                columns: new[] { "IdTipoAcomodacao", "NomeTipoAcomodacao" },
                values: new object[] { 1, "Quarto" });

            migrationBuilder.InsertData(
                table: "TiposAcomodacoes",
                columns: new[] { "IdTipoAcomodacao", "NomeTipoAcomodacao" },
                values: new object[] { 2, "Pousada" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cpf", "DataNascimento", "Discriminator", "Email", "Nome", "Senha", "Sexo", "Telefone" },
                values: new object[] { 1, "111.111.111-11", new DateTime(2003, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", "nicolasbassini@hotmail.com", "Nicolas", "$2a$10$R1wO91Bzdj.7Xz74dZhFcucaFarD0ADszqBu6HIrueZ/O1wOgMDWm", 1, "+5528999752520" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Cpf", "DataNascimento", "Discriminator", "Email", "Cliente_FkEndereco", "Nome", "Senha", "Sexo", "Telefone" },
                values: new object[] { 3, "333.333.333-33", new DateTime(2004, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cliente", "anna@email.com", null, "Anna", "$2a$10$drRKLSDft7ypuwkTDJkcXeSnOi6HTtfECJqrcxIOvXO20LMM5b30C", 2, "+5528999967759" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "CNPJ", "Celular", "Cpf", "DataNascimento", "Discriminator", "Email", "FkEndereco", "MediaAvaliacao", "Nome", "NomeFantasia", "RazaoSocial", "Senha", "Sexo", "Telefone" },
                values: new object[] { 2, "12312312312312", "+5528999999998", "222.222.222-22", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Responsavel", "dono@empresa.com", 1, null, "Dono Empresa", "Empresa Fantasia", "Empresa Corporation", "$2a$10$5T.WEOHhFeCs3vBQaUsC1OaU/k1r54fPGntGneNgPCyNHK36qJCzi", 2, "+5528999999999" });

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkAdministrador",
                table: "Acomodacoes",
                column: "FkAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkResponsavel",
                table: "Acomodacoes",
                column: "FkResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkTipoAcomodacao",
                table: "Acomodacoes",
                column: "FkTipoAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkAcomodacao",
                table: "Avaliacoes",
                column: "FkAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkAdministrador",
                table: "Avaliacoes",
                column: "FkAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkCliente",
                table: "Avaliacoes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ResponsavelIdUsuario",
                table: "Contatos",
                column: "ResponsavelIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkAcomodacao",
                table: "Reservas",
                column: "FkAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkCliente",
                table: "Reservas",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cliente_FkEndereco",
                table: "Usuarios",
                column: "Cliente_FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkEndereco",
                table: "Usuarios",
                column: "FkEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Acomodacoes");

            migrationBuilder.DropTable(
                name: "TiposAcomodacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
