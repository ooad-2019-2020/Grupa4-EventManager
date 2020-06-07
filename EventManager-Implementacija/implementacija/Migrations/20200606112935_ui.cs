using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace implementacija.Migrations
{
    public partial class ui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    NacinPlacanjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanjaId);
                });

            migrationBuilder.CreateTable(
                name: "Sistem",
                columns: table => new
                {
                    SistemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistem", x => x.SistemId);
                });

            migrationBuilder.CreateTable(
                name: "TipFizickogLica",
                columns: table => new
                {
                    TipFizickogLicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    popust = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipFizickogLica", x => x.TipFizickogLicaId);
                });

            migrationBuilder.CreateTable(
                name: "Ustanova",
                columns: table => new
                {
                    UstanovaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    brojRacunaUBanci = table.Column<string>(nullable: true),
                    brojTelefona = table.Column<string>(nullable: true),
                    stanjeUplata = table.Column<double>(nullable: false),
                    odgovornoLiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ustanova", x => x.UstanovaId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaKarte",
                columns: table => new
                {
                    VrstaKarteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preporucenaCijena = table.Column<double>(nullable: false),
                    preporuceniPopust = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaKarte", x => x.VrstaKarteId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaObavijesti",
                columns: table => new
                {
                    VrstaObavijestiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaObavijesti", x => x.VrstaObavijestiId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    ime = table.Column<string>(nullable: true),
                    datumPrijave = table.Column<DateTime>(nullable: false),
                    adresa = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    SistemId = table.Column<int>(nullable: true),
                    UstanovaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisnik_Sistem_SistemId",
                        column: x => x.SistemId,
                        principalTable: "Sistem",
                        principalColumn: "SistemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Ustanova_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanova",
                        principalColumn: "UstanovaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArhivaDogadjaj",
                columns: table => new
                {
                    ArhivaDogadjajaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    UstanovaId = table.Column<int>(nullable: false),
                    cijenaRezervacije = table.Column<double>(nullable: false),
                    popust = table.Column<bool>(nullable: false),
                    iznosPopusta = table.Column<int>(nullable: false),
                    DogadjajId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaDogadjaj", x => x.ArhivaDogadjajaId);
                    table.ForeignKey(
                        name: "FK_ArhivaDogadjaj_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArhivaDogadjaj_Ustanova_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanova",
                        principalColumn: "UstanovaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArhivaKorisnikFL",
                columns: table => new
                {
                    ArhivaKorisnikaFLId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    izvrsioTransakciju = table.Column<int>(nullable: false),
                    ukupnoUplatio = table.Column<double>(nullable: false),
                    bioOdgovornoLice = table.Column<bool>(nullable: false),
                    TipFizickogLicaId = table.Column<int>(nullable: false),
                    kreiraoRacun = table.Column<DateTime>(nullable: false),
                    napustioApp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaKorisnikFL", x => x.ArhivaKorisnikaFLId);
                    table.ForeignKey(
                        name: "FK_ArhivaKorisnikFL_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArhivaKorisnikFL_TipFizickogLica_TipFizickogLicaId",
                        column: x => x.TipFizickogLicaId,
                        principalTable: "TipFizickogLica",
                        principalColumn: "TipFizickogLicaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArhivaUstanova",
                columns: table => new
                {
                    ArhivaKorisnikaUstanovaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    imaoUplata = table.Column<double>(nullable: false),
                    kreiraoRacun = table.Column<DateTime>(nullable: false),
                    napustioSistem = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaUstanova", x => x.ArhivaKorisnikaUstanovaId);
                    table.ForeignKey(
                        name: "FK_ArhivaUstanova_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FizickoLice",
                columns: table => new
                {
                    FizickoLiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    brojKartice = table.Column<string>(nullable: true),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    tipFizickogLica = table.Column<int>(nullable: false),
                    VIP = table.Column<bool>(nullable: false),
                    stanjeRacuna = table.Column<double>(nullable: false),
                    odgovornoLice = table.Column<bool>(nullable: false),
                    TipFizickogLicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickoLice", x => x.FizickoLiceId);
                    table.ForeignKey(
                        name: "FK_FizickoLice_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FizickoLice_TipFizickogLica_TipFizickogLicaId",
                        column: x => x.TipFizickogLicaId,
                        principalTable: "TipFizickogLica",
                        principalColumn: "TipFizickogLicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    tekstObavijesti = table.Column<string>(nullable: true),
                    datumSlanja = table.Column<DateTime>(nullable: false),
                    VrstaObavijestiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestId);
                    table.ForeignKey(
                        name: "FK_Obavijest_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obavijest_VrstaObavijesti_VrstaObavijestiId",
                        column: x => x.VrstaObavijestiId,
                        principalTable: "VrstaObavijesti",
                        principalColumn: "VrstaObavijestiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    TransakcijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    ukupnoZaUplatu = table.Column<double>(nullable: false),
                    NacinPlacanjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.TransakcijaId);
                    table.ForeignKey(
                        name: "FK_Transakcija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transakcija_NacinPlacanja_NacinPlacanjaId",
                        column: x => x.NacinPlacanjaId,
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanjaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    ZahtjevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    tekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.ZahtjevId);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogadjaj",
                columns: table => new
                {
                    DogadjajId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UstanovaId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    kapacitet = table.Column<int>(nullable: false),
                    cijena = table.Column<double>(nullable: false),
                    datumDogadjaja = table.Column<DateTime>(nullable: false),
                    trenutniKapacitet = table.Column<int>(nullable: false),
                    ArhivaDogadjajaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaj", x => x.DogadjajId);
                    table.ForeignKey(
                        name: "FK_Dogadjaj_ArhivaDogadjaj_ArhivaDogadjajaId",
                        column: x => x.ArhivaDogadjajaId,
                        principalTable: "ArhivaDogadjaj",
                        principalColumn: "ArhivaDogadjajaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogadjaj_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogadjaj_Ustanova_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanova",
                        principalColumn: "UstanovaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recenzija = table.Column<string>(nullable: true),
                    brojZvjezdica = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    datumOstavljanja = table.Column<DateTime>(nullable: false),
                    DogadjajId = table.Column<int>(nullable: false),
                    neprimjerenKomentar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarId);
                    table.ForeignKey(
                        name: "FK_Komentar_Dogadjaj_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaj",
                        principalColumn: "DogadjajId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    osobaRezervacija = table.Column<int>(nullable: false),
                    UstanovaId = table.Column<int>(nullable: false),
                    DogadjajId = table.Column<int>(nullable: false),
                    VrstaKarteId = table.Column<int>(nullable: false),
                    cijena = table.Column<double>(nullable: false),
                    brojRezervisanihMjesta = table.Column<int>(nullable: false),
                    datumRezervacije = table.Column<DateTime>(nullable: false),
                    ukupnoZaUplatu = table.Column<double>(nullable: false),
                    datumDogadjaja = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Dogadjaj_DogadjajId",
                        column: x => x.DogadjajId,
                        principalTable: "Dogadjaj",
                        principalColumn: "DogadjajId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Ustanova_UstanovaId",
                        column: x => x.UstanovaId,
                        principalTable: "Ustanova",
                        principalColumn: "UstanovaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_VrstaKarte_VrstaKarteId",
                        column: x => x.VrstaKarteId,
                        principalTable: "VrstaKarte",
                        principalColumn: "VrstaKarteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_KorisnikId",
                table: "Admin",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaDogadjaj_KorisnikId",
                table: "ArhivaDogadjaj",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaDogadjaj_UstanovaId",
                table: "ArhivaDogadjaj",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaKorisnikFL_KorisnikId",
                table: "ArhivaKorisnikFL",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaKorisnikFL_TipFizickogLicaId",
                table: "ArhivaKorisnikFL",
                column: "TipFizickogLicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaUstanova_KorisnikId",
                table: "ArhivaUstanova",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaj_ArhivaDogadjajaId",
                table: "Dogadjaj",
                column: "ArhivaDogadjajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaj_KorisnikId",
                table: "Dogadjaj",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaj_UstanovaId",
                table: "Dogadjaj",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickoLice_KorisnikId",
                table: "FizickoLice",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_FizickoLice_TipFizickogLicaId",
                table: "FizickoLice",
                column: "TipFizickogLicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_DogadjajId",
                table: "Komentar",
                column: "DogadjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KorisnikId",
                table: "Komentar",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SistemId",
                table: "Korisnik",
                column: "SistemId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UstanovaId",
                table: "Korisnik",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_KorisnikId",
                table: "Obavijest",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_VrstaObavijestiId",
                table: "Obavijest",
                column: "VrstaObavijestiId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_DogadjajId",
                table: "Rezervacija",
                column: "DogadjajId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikId",
                table: "Rezervacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UstanovaId",
                table: "Rezervacija",
                column: "UstanovaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VrstaKarteId",
                table: "Rezervacija",
                column: "VrstaKarteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_KorisnikId",
                table: "Transakcija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_NacinPlacanjaId",
                table: "Transakcija",
                column: "NacinPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_KorisnikId",
                table: "Zahtjev",
                column: "KorisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ArhivaKorisnikFL");

            migrationBuilder.DropTable(
                name: "ArhivaUstanova");

            migrationBuilder.DropTable(
                name: "FizickoLice");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "TipFizickogLica");

            migrationBuilder.DropTable(
                name: "VrstaObavijesti");

            migrationBuilder.DropTable(
                name: "Dogadjaj");

            migrationBuilder.DropTable(
                name: "VrstaKarte");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "ArhivaDogadjaj");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Sistem");

            migrationBuilder.DropTable(
                name: "Ustanova");
        }
    }
}
