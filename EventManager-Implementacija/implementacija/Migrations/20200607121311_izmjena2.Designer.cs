﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using implementacija.Models;

namespace implementacija.Migrations
{
    [DbContext(typeof(EMContext))]
    [Migration("20200607121311_izmjena2")]
    partial class izmjena2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("implementacija.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("implementacija.Models.ArhivaDogadjaja", b =>
                {
                    b.Property<int>("ArhivaDogadjajaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DogadjajId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UstanovaId")
                        .HasColumnType("int");

                    b.Property<double>("cijenaRezervacije")
                        .HasColumnType("float");

                    b.Property<int>("iznosPopusta")
                        .HasColumnType("int");

                    b.Property<bool>("popust")
                        .HasColumnType("bit");

                    b.HasKey("ArhivaDogadjajaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UstanovaId");

                    b.ToTable("ArhivaDogadjaj");
                });

            modelBuilder.Entity("implementacija.Models.ArhivaKorisnikaFL", b =>
                {
                    b.Property<int>("ArhivaKorisnikaFLId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("TipFizickogLicaId")
                        .HasColumnType("int");

                    b.Property<bool>("bioOdgovornoLice")
                        .HasColumnType("bit");

                    b.Property<int>("izvrsioTransakciju")
                        .HasColumnType("int");

                    b.Property<DateTime>("kreiraoRacun")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("napustioApp")
                        .HasColumnType("datetime2");

                    b.Property<double>("ukupnoUplatio")
                        .HasColumnType("float");

                    b.HasKey("ArhivaKorisnikaFLId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipFizickogLicaId");

                    b.ToTable("ArhivaKorisnikFL");
                });

            modelBuilder.Entity("implementacija.Models.ArhivaKorisnikaUstanova", b =>
                {
                    b.Property<int>("ArhivaKorisnikaUstanovaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<double>("imaoUplata")
                        .HasColumnType("float");

                    b.Property<DateTime>("kreiraoRacun")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("napustioSistem")
                        .HasColumnType("datetime2");

                    b.HasKey("ArhivaKorisnikaUstanovaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("ArhivaUstanova");
                });

            modelBuilder.Entity("implementacija.Models.Dogadjaj", b =>
                {
                    b.Property<int>("DogadjajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArhivaDogadjajaId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UstanovaId")
                        .HasColumnType("int");

                    b.Property<double>("cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("datumDogadjaja")
                        .HasColumnType("datetime2");

                    b.Property<int>("kapacitet")
                        .HasColumnType("int");

                    b.Property<int>("trenutniKapacitet")
                        .HasColumnType("int");

                    b.HasKey("DogadjajId");

                    b.HasIndex("ArhivaDogadjajaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UstanovaId");

                    b.ToTable("Dogadjaj");
                });

            modelBuilder.Entity("implementacija.Models.FizickoLice", b =>
                {
                    b.Property<int>("FizickoLiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("TipFizickogLicaId")
                        .HasColumnType("int");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.Property<string>("brojKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("odgovornoLice")
                        .HasColumnType("bit");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stanjeRacuna")
                        .HasColumnType("float");

                    b.Property<int>("tipFizickogLica")
                        .HasColumnType("int");

                    b.HasKey("FizickoLiceId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipFizickogLicaId");

                    b.ToTable("FizickoLice");
                });

            modelBuilder.Entity("implementacija.Models.Komentar", b =>
                {
                    b.Property<int>("KomentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DogadjajId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("brojZvjezdica")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumOstavljanja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("neprimjerenKomentar")
                        .HasColumnType("bit");

                    b.Property<string>("recenzija")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KomentarId");

                    b.HasIndex("DogadjajId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("implementacija.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SistemId")
                        .HasColumnType("int");

                    b.Property<int?>("UstanovaId")
                        .HasColumnType("int");

                    b.Property<string>("adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikId");

                    b.HasIndex("SistemId");

                    b.HasIndex("UstanovaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("implementacija.Models.NacinPlacanja", b =>
                {
                    b.Property<int>("NacinPlacanjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("NacinPlacanjaId");

                    b.ToTable("NacinPlacanja");
                });

            modelBuilder.Entity("implementacija.Models.Obavijest", b =>
                {
                    b.Property<int>("ObavijestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("VrstaObavijestiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("tekstObavijesti")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObavijestId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("VrstaObavijestiId");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("implementacija.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DogadjajId")
                        .HasColumnType("int");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UstanovaId")
                        .HasColumnType("int");

                    b.Property<int>("VrstaKarteId")
                        .HasColumnType("int");

                    b.Property<int>("brojRezervisanihMjesta")
                        .HasColumnType("int");

                    b.Property<double>("cijena")
                        .HasColumnType("float");

                    b.Property<DateTime>("datumDogadjaja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("osobaRezervacija")
                        .HasColumnType("int");

                    b.Property<double>("ukupnoZaUplatu")
                        .HasColumnType("float");

                    b.HasKey("RezervacijaId");

                    b.HasIndex("DogadjajId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UstanovaId");

                    b.HasIndex("VrstaKarteId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("implementacija.Models.Sistem", b =>
                {
                    b.Property<int>("SistemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("SistemId");

                    b.ToTable("Sistem");
                });

            modelBuilder.Entity("implementacija.Models.TipFizickogLica", b =>
                {
                    b.Property<int>("TipFizickogLicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("popust")
                        .HasColumnType("bit");

                    b.HasKey("TipFizickogLicaId");

                    b.ToTable("TipFizickogLica");
                });

            modelBuilder.Entity("implementacija.Models.Transakcija", b =>
                {
                    b.Property<int>("TransakcijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("NacinPlacanjaId")
                        .HasColumnType("int");

                    b.Property<double>("ukupnoZaUplatu")
                        .HasColumnType("float");

                    b.HasKey("TransakcijaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("NacinPlacanjaId");

                    b.ToTable("Transakcija");
                });

            modelBuilder.Entity("implementacija.Models.Ustanova", b =>
                {
                    b.Property<int>("UstanovaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("brojRacunaUBanci")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("odgovornoLiceId")
                        .HasColumnType("int");

                    b.Property<double>("stanjeUplata")
                        .HasColumnType("float");

                    b.HasKey("UstanovaId");

                    b.ToTable("Ustanova");
                });

            modelBuilder.Entity("implementacija.Models.VIP", b =>
                {
                    b.Property<int>("VIPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("TipFizickogLicaId")
                        .HasColumnType("int");

                    b.Property<string>("brojKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("iznosClanarine")
                        .HasColumnType("float");

                    b.Property<bool>("odgovornoLice")
                        .HasColumnType("bit");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stanjeRacuna")
                        .HasColumnType("float");

                    b.Property<int>("tipFizickogLica")
                        .HasColumnType("int");

                    b.Property<int>("trajanjeClanarine")
                        .HasColumnType("int");

                    b.Property<bool>("uplatioClanarinu")
                        .HasColumnType("bit");

                    b.HasKey("VIPId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipFizickogLicaId");

                    b.ToTable("VIP");
                });

            modelBuilder.Entity("implementacija.Models.VrstaKarte", b =>
                {
                    b.Property<int>("VrstaKarteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("preporucenaCijena")
                        .HasColumnType("float");

                    b.Property<int>("preporuceniPopust")
                        .HasColumnType("int");

                    b.HasKey("VrstaKarteId");

                    b.ToTable("VrstaKarte");
                });

            modelBuilder.Entity("implementacija.Models.VrstaObavijesti", b =>
                {
                    b.Property<int>("VrstaObavijestiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VrstaObavijestiId");

                    b.ToTable("VrstaObavijesti");
                });

            modelBuilder.Entity("implementacija.Models.Zahtjev", b =>
                {
                    b.Property<int>("ZahtjevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZahtjevId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Zahtjev");
                });

            modelBuilder.Entity("implementacija.Models.Admin", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Admin")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.ArhivaDogadjaja", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("ArhivaDogadjaja")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.Ustanova", "Ustanova")
                        .WithMany("ArhivaDogadjaja")
                        .HasForeignKey("UstanovaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.ArhivaKorisnikaFL", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("ArhivaKorisnikaFL")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.TipFizickogLica", "TipFizickogLica")
                        .WithMany("ArhivaKorisnikaFL")
                        .HasForeignKey("TipFizickogLicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.ArhivaKorisnikaUstanova", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("ArhivaKorisnikaUstanova")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.Dogadjaj", b =>
                {
                    b.HasOne("implementacija.Models.ArhivaDogadjaja", null)
                        .WithMany("Dogadjaj")
                        .HasForeignKey("ArhivaDogadjajaId");

                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.Ustanova", "Ustanova")
                        .WithMany("Dogadjaj")
                        .HasForeignKey("UstanovaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.FizickoLice", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("FizickoLice")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.TipFizickogLica", "TipFizickogLica")
                        .WithMany("FizickoLice")
                        .HasForeignKey("TipFizickogLicaId");
                });

            modelBuilder.Entity("implementacija.Models.Komentar", b =>
                {
                    b.HasOne("implementacija.Models.Dogadjaj", "Dogadjaj")
                        .WithMany()
                        .HasForeignKey("DogadjajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Komentar")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.Korisnik", b =>
                {
                    b.HasOne("implementacija.Models.Sistem", "Sistem")
                        .WithMany("Korisnik")
                        .HasForeignKey("SistemId");

                    b.HasOne("implementacija.Models.Ustanova", "Ustanova")
                        .WithMany("Korisnik")
                        .HasForeignKey("UstanovaId");
                });

            modelBuilder.Entity("implementacija.Models.Obavijest", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Obavijest")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.VrstaObavijesti", "VrstaObavijesti")
                        .WithMany("Obavijest")
                        .HasForeignKey("VrstaObavijestiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.Rezervacija", b =>
                {
                    b.HasOne("implementacija.Models.Dogadjaj", "Dogadjaj")
                        .WithMany("Rezervacija")
                        .HasForeignKey("DogadjajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Rezervacija")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("implementacija.Models.Ustanova", "Ustanova")
                        .WithMany("Rezervacija")
                        .HasForeignKey("UstanovaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.VrstaKarte", "VrstaKarte")
                        .WithMany("Rezervacija")
                        .HasForeignKey("VrstaKarteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.Transakcija", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Transakcija")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.NacinPlacanja", "NacinPlacanja")
                        .WithMany("Transakcija")
                        .HasForeignKey("NacinPlacanjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("implementacija.Models.VIP", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("implementacija.Models.TipFizickogLica", "TipFizickogLica")
                        .WithMany()
                        .HasForeignKey("TipFizickogLicaId");
                });

            modelBuilder.Entity("implementacija.Models.Zahtjev", b =>
                {
                    b.HasOne("implementacija.Models.Korisnik", "Korisnik")
                        .WithMany("Zahtjev")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
