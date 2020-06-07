using Microsoft.EntityFrameworkCore.Migrations;

namespace implementacija.Migrations
{
    public partial class izmjenaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registracija",
                columns: table => new
                {
                    RegistracijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    FizickoLiceId = table.Column<int>(nullable: false),
                    VIPId = table.Column<int>(nullable: false),
                    UstanovaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registracija", x => x.RegistracijaId);
                    table.ForeignKey(
                        name: "FK_Registracija_FizickoLice_FizickoLiceId",
                        column: x => x.FizickoLiceId,
                        principalTable: "FizickoLice",
                        principalColumn: "FizickoLiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registracija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registracija_Ustanova_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanova",
                        principalColumn: "UstanovaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registracija_VIP_VIPId",
                        column: x => x.VIPId,
                        principalTable: "VIP",
                        principalColumn: "VIPId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registracija_FizickoLiceId",
                table: "Registracija",
                column: "FizickoLiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Registracija_KorisnikId",
                table: "Registracija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Registracija_UstanovaId",
                table: "Registracija",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_Registracija_VIPId",
                table: "Registracija",
                column: "VIPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registracija");
        }
    }
}
