using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$Xw2u7JbyYXaSUY59f/hi/uW2U7siVMOVwQ6jJR5RZ3IFeztF9JWOm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 3,
                column: "Senha",
                value: "$2a$10$nx3K9s.9Pt1drM//7P.1qulSyhODxnEoVeRD.tvE2YRkVjUg5vUta");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$uGdrgDW...CjwhHD3NnWbOoixsx0YSRm5YArZcFw.cnbElR/X7MKW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Reservas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$R1wO91Bzdj.7Xz74dZhFcucaFarD0ADszqBu6HIrueZ/O1wOgMDWm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 3,
                column: "Senha",
                value: "$2a$10$drRKLSDft7ypuwkTDJkcXeSnOi6HTtfECJqrcxIOvXO20LMM5b30C");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$5T.WEOHhFeCs3vBQaUsC1OaU/k1r54fPGntGneNgPCyNHK36qJCzi");
        }
    }
}
