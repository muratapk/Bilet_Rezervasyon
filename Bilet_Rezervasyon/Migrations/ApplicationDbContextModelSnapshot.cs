﻿// <auto-generated />
using System;
using Bilet_Rezervasyon.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bilet_Rezervasyon.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Acenta", b =>
                {
                    b.Property<int>("AcentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcentaId"));

                    b.Property<string>("AcentaAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Kurulus_Tarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcentaId");

                    b.ToTable("Acenta");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Bilet", b =>
                {
                    b.Property<int>("BiletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BiletId"));

                    b.Property<TimeOnly>("BSaati")
                        .HasColumnType("time");

                    b.Property<int?>("BSayi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BTarih")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("BiletDurum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Gecer_Sure")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Koltuk")
                        .HasColumnType("int");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<int?>("PNR")
                        .HasColumnType("int");

                    b.Property<int?>("PersonelId")
                        .HasColumnType("int");

                    b.Property<int?>("SeferId")
                        .HasColumnType("int");

                    b.HasKey("BiletId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("SeferId");

                    b.ToTable("Bilets");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Gise", b =>
                {
                    b.Property<int>("GiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiseId"));

                    b.Property<string>("GiseAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GiseId");

                    b.ToTable("Gises");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.KartBilgi", b =>
                {
                    b.Property<int>("KartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KartId"));

                    b.Property<int?>("Cvc")
                        .HasColumnType("int");

                    b.Property<string>("KartNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KartSahibi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<string>("SonTarih")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KartId");

                    b.HasIndex("MusteriId");

                    b.ToTable("KartBilgi");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MusteriId"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dogum_Tarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Yas")
                        .HasColumnType("int");

                    b.HasKey("MusteriId");

                    b.ToTable("Musteri");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Odeme", b =>
                {
                    b.Property<int?>("OdemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("OdemeId"));

                    b.Property<int?>("BiletId")
                        .HasColumnType("int");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.HasKey("OdemeId");

                    b.HasIndex("BiletId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Odeme");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Personel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelId"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dogum_Tarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiseId")
                        .HasColumnType("int");

                    b.Property<string>("SigortaNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TcNo")
                        .HasColumnType("int");

                    b.HasKey("PersonelId");

                    b.HasIndex("GiseId");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Rezervasyon", b =>
                {
                    b.Property<int>("RezervasyonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RezervasyonId"));

                    b.Property<string>("Bicim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BiletId")
                        .HasColumnType("int");

                    b.Property<int?>("MusteriId")
                        .HasColumnType("int");

                    b.Property<int?>("Sayisi")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("RezervasyonId");

                    b.HasIndex("BiletId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Rezervasyons");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Sefer", b =>
                {
                    b.Property<int>("SeferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeferId"));

                    b.Property<int>("AcentaId")
                        .HasColumnType("int");

                    b.Property<string>("Donus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gidis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly?>("Saati")
                        .HasColumnType("time");

                    b.Property<string>("SeferAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeferKodu")
                        .HasColumnType("int");

                    b.Property<decimal?>("Ucreti")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SeferId");

                    b.HasIndex("AcentaId");

                    b.ToTable("Sefers");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteId");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Bilet", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Personel", "Personel")
                        .WithMany("Bilets")
                        .HasForeignKey("PersonelId");

                    b.HasOne("Bilet_Rezervasyon.Models.Sefer", "Sefer")
                        .WithMany("Bilets")
                        .HasForeignKey("SeferId");

                    b.Navigation("Personel");

                    b.Navigation("Sefer");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.KartBilgi", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Musteri", "Musteri")
                        .WithMany("KartBilgi")
                        .HasForeignKey("MusteriId");

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Odeme", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Bilet", "Bilet")
                        .WithMany()
                        .HasForeignKey("BiletId");

                    b.HasOne("Bilet_Rezervasyon.Models.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId");

                    b.Navigation("Bilet");

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Personel", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Gise", "Gise")
                        .WithMany("Personels")
                        .HasForeignKey("GiseId");

                    b.Navigation("Gise");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Rezervasyon", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Bilet", "Bilet")
                        .WithMany("Rezervasons")
                        .HasForeignKey("BiletId");

                    b.HasOne("Bilet_Rezervasyon.Models.Musteri", "Musteri")
                        .WithMany("Rezervasyons")
                        .HasForeignKey("MusteriId");

                    b.Navigation("Bilet");

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Sefer", b =>
                {
                    b.HasOne("Bilet_Rezervasyon.Models.Acenta", "Acenta")
                        .WithMany("Sefers")
                        .HasForeignKey("AcentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acenta");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Acenta", b =>
                {
                    b.Navigation("Sefers");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Bilet", b =>
                {
                    b.Navigation("Rezervasons");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Gise", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Musteri", b =>
                {
                    b.Navigation("KartBilgi");

                    b.Navigation("Rezervasyons");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Personel", b =>
                {
                    b.Navigation("Bilets");
                });

            modelBuilder.Entity("Bilet_Rezervasyon.Models.Sefer", b =>
                {
                    b.Navigation("Bilets");
                });
#pragma warning restore 612, 618
        }
    }
}
