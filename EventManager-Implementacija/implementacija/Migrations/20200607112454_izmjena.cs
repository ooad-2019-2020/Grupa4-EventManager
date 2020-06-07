using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace implementacija.Migrations
{
    public partial class izmjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VIP",
                columns: table => new
                {
                    VIPId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FizickoLiceId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    brojKartice = table.Column<string>(nullable: true),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    tipFizickogLica = table.Column<int>(nullable: false),
                    stanjeRacuna = table.Column<double>(nullable: false),
                    odgovornoLice = table.Column<bool>(nullable: false),
                    uplatioClanarinu = table.Column<bool>(nullable: false),
                    iznosClanarine = table.Column<double>(nullable: false),
                    trajanjeClanarine = table.Column<int>(nullable: false),
                    TipFizickogLicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIP", x => x.VIPId);
                    table.ForeignKey(
                        name: "FK_VIP_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VIP_TipFizickogLica_TipFizickogLicaId",
                        column: x => x.TipFizickogLicaId,
                        principalTable: "TipFizickogLica",
                        principalColumn: "TipFizickogLicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VIP_KorisnikId",
                table: "VIP",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_VIP_TipFizickogLicaId",
                table: "VIP",
                column: "TipFizickogLicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIP");
        }
    }
}
