using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilet_Rezervasyon.Migrations
{
    /// <inheritdoc />
    public partial class sonuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acenta",
                columns: table => new
                {
                    AcentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcentaAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kurulus_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acenta", x => x.AcentaId);
                });

            migrationBuilder.CreateTable(
                name: "Gises",
                columns: table => new
                {
                    GiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiseAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gises", x => x.GiseId);
                });

            migrationBuilder.CreateTable(
                name: "Musteri",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dogum_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteri", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Sefers",
                columns: table => new
                {
                    SeferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcentaId = table.Column<int>(type: "int", nullable: false),
                    SeferAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeferKodu = table.Column<int>(type: "int", nullable: false),
                    Gidis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Donus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ucreti = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Saati = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sefers", x => x.SeferId);
                    table.ForeignKey(
                        name: "FK_Sefers_Acenta_AcentaId",
                        column: x => x.AcentaId,
                        principalTable: "Acenta",
                        principalColumn: "AcentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNo = table.Column<int>(type: "int", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dogum_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigortaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personel_Gises_GiseId",
                        column: x => x.GiseId,
                        principalTable: "Gises",
                        principalColumn: "GiseId");
                });

            migrationBuilder.CreateTable(
                name: "KartBilgi",
                columns: table => new
                {
                    KartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    KartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartSahibi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SonTarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cvc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartBilgi", x => x.KartId);
                    table.ForeignKey(
                        name: "FK_KartBilgi_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "MusteriId");
                });

            migrationBuilder.CreateTable(
                name: "Bilets",
                columns: table => new
                {
                    BiletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    SeferId = table.Column<int>(type: "int", nullable: true),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    BTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BSaati = table.Column<TimeOnly>(type: "time", nullable: false),
                    PNR = table.Column<int>(type: "int", nullable: true),
                    Koltuk = table.Column<int>(type: "int", nullable: true),
                    BSayi = table.Column<int>(type: "int", nullable: true),
                    Gecer_Sure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BiletDurum = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilets", x => x.BiletId);
                    table.ForeignKey(
                        name: "FK_Bilets_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId");
                    table.ForeignKey(
                        name: "FK_Bilets_Sefers_SeferId",
                        column: x => x.SeferId,
                        principalTable: "Sefers",
                        principalColumn: "SeferId");
                });

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    BiletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeme", x => x.OdemeId);
                    table.ForeignKey(
                        name: "FK_Odeme_Bilets_BiletId",
                        column: x => x.BiletId,
                        principalTable: "Bilets",
                        principalColumn: "BiletId");
                    table.ForeignKey(
                        name: "FK_Odeme_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "MusteriId");
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    RezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
                    BiletId = table.Column<int>(type: "int", nullable: true),
                    Bicim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sayisi = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.RezervasyonId);
                    table.ForeignKey(
                        name: "FK_Rezervasyons_Bilets_BiletId",
                        column: x => x.BiletId,
                        principalTable: "Bilets",
                        principalColumn: "BiletId");
                    table.ForeignKey(
                        name: "FK_Rezervasyons_Musteri_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteri",
                        principalColumn: "MusteriId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilets_PersonelId",
                table: "Bilets",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilets_SeferId",
                table: "Bilets",
                column: "SeferId");

            migrationBuilder.CreateIndex(
                name: "IX_KartBilgi_MusteriId",
                table: "KartBilgi",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_BiletId",
                table: "Odeme",
                column: "BiletId");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_MusteriId",
                table: "Odeme",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_GiseId",
                table: "Personel",
                column: "GiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_BiletId",
                table: "Rezervasyons",
                column: "BiletId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_MusteriId",
                table: "Rezervasyons",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_AcentaId",
                table: "Sefers",
                column: "AcentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartBilgi");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropTable(
                name: "Rezervasyons");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Bilets");

            migrationBuilder.DropTable(
                name: "Musteri");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Sefers");

            migrationBuilder.DropTable(
                name: "Gises");

            migrationBuilder.DropTable(
                name: "Acenta");
        }
    }
}
