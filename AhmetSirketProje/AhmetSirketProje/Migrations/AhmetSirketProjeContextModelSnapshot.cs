// <auto-generated />
using System;
using AhmetSirketProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AhmetSirketProje.Migrations
{
    [DbContext(typeof(AhmetSirketProjeContext))]
    partial class AhmetSirketProjeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AhmetSirketProje.Entities.Calisanlar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int?>("KategorilerId")
                        .HasColumnType("int");

                    b.Property<decimal>("SaatlikUcret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("KategorilerId");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Isler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CalisanId")
                        .HasColumnType("int");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("Saat")
                        .HasColumnType("int");

                    b.Property<int>("SirketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("SirketId");

                    b.ToTable("Isler");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Kategoriler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Sirketler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SirketAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sirketler");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Calisanlar", b =>
                {
                    b.HasOne("AhmetSirketProje.Entities.Kategoriler", null)
                        .WithMany("Calisanlar")
                        .HasForeignKey("KategorilerId");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Isler", b =>
                {
                    b.HasOne("AhmetSirketProje.Entities.Calisanlar", "Calisan")
                        .WithMany("Isler")
                        .HasForeignKey("CalisanId");

                    b.HasOne("AhmetSirketProje.Entities.Kategoriler", "Kategori")
                        .WithMany("Isler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AhmetSirketProje.Entities.Sirketler", "Sirket")
                        .WithMany("Isler")
                        .HasForeignKey("SirketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Kategori");

                    b.Navigation("Sirket");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Calisanlar", b =>
                {
                    b.Navigation("Isler");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Kategoriler", b =>
                {
                    b.Navigation("Calisanlar");

                    b.Navigation("Isler");
                });

            modelBuilder.Entity("AhmetSirketProje.Entities.Sirketler", b =>
                {
                    b.Navigation("Isler");
                });
#pragma warning restore 612, 618
        }
    }
}
