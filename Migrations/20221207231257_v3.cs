using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$lraGUtJkgRPYULZyZ6woXuj3E84PIE6gv2nXdBf7IieNUkHMpsPKe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 3,
                column: "Senha",
                value: "$2a$10$nurhPWOXEHWWYr0ofVSNpOc/v3r4.0oA79WvL2yagd.IQZ.WTiykq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$4W3X.k9Te4rigXlgDbXEs.cOzSs8NnwzbcvCj1nFTBVuJ3erJRxNK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
