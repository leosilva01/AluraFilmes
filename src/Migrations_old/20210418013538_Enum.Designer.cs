﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210418013538_Enum")]
    partial class Enum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Api.Domain.Entities.AtorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("actor_id");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(45)")
                        .HasColumnName("first_name");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(45)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("Now()");

                    b.HasKey("Id");

                    b.HasAlternateKey("PrimeiroNome", "UltimoNome");

                    b.HasIndex("PrimeiroNome");

                    b.ToTable("actor");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeAtorEntity", b =>
                {
                    b.Property<int>("film_id")
                        .HasColumnType("int");

                    b.Property<int>("actor_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("Now()");

                    b.HasKey("film_id", "actor_id");

                    b.HasIndex("actor_id");

                    b.ToTable("film_actor");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    b.Property<string>("AnoLancamento")
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("release_year");

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("rating");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<short>("Duracao")
                        .HasColumnType("smallint")
                        .HasColumnName("length");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)")
                        .HasColumnName("title");

                    b.Property<int>("language_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("Now()");

                    b.Property<int?>("original_language_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Titulo");

                    b.HasIndex("language_id");

                    b.HasIndex("original_language_id");

                    b.ToTable("film");
                });

            modelBuilder.Entity("Api.Domain.Entities.IdiomaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("language_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("char(20)")
                        .HasColumnName("name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("Now()");

                    b.HasKey("Id");

                    b.HasIndex("Nome");

                    b.ToTable("language");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeAtorEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.AtorEntity", "Ator")
                        .WithMany("Filmografia")
                        .HasForeignKey("actor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.FilmeEntity", "Filme")
                        .WithMany("Atores")
                        .HasForeignKey("film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.IdiomaEntity", "IdiomaFalado")
                        .WithMany("FilmesFalados")
                        .HasForeignKey("language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.IdiomaEntity", "IdiomaOriginal")
                        .WithMany("FilmesOriginais")
                        .HasForeignKey("original_language_id");

                    b.Navigation("IdiomaFalado");

                    b.Navigation("IdiomaOriginal");
                });

            modelBuilder.Entity("Api.Domain.Entities.AtorEntity", b =>
                {
                    b.Navigation("Filmografia");
                });

            modelBuilder.Entity("Api.Domain.Entities.FilmeEntity", b =>
                {
                    b.Navigation("Atores");
                });

            modelBuilder.Entity("Api.Domain.Entities.IdiomaEntity", b =>
                {
                    b.Navigation("FilmesFalados");

                    b.Navigation("FilmesOriginais");
                });
#pragma warning restore 612, 618
        }
    }
}
