﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ModeloRelacionamentos.Infra;
using System;

namespace ModeloRelacionamentos.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Cursos", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("RUA")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.ToTable("CURSOS","dbo");
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.CursosPessoa", b =>
                {
                    b.Property<int>("CodCursos")
                        .HasColumnName("CODCRUSOS");

                    b.Property<int>("CodPessoa")
                        .HasColumnName("CODPESSOA");

                    b.HasKey("CodCursos", "CodPessoa");

                    b.HasIndex("CodPessoa");

                    b.ToTable("CURSOSPESSOA");
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Endereco", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoPessoa")
                        .HasColumnName("CodigoPessoa");

                    b.Property<int>("Numero")
                        .HasColumnName("NUMERO")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnName("RUA")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoPessoa")
                        .IsUnique();

                    b.ToTable("ENDERECO","dbo");
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Filhos", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CodigoPai")
                        .HasColumnName("CODIGOPAI");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoPai");

                    b.ToTable("FILHOS","dbo");
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Pessoa", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DATACADASTRO")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Codigo");

                    b.ToTable("PESSOA","dbo");
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.CursosPessoa", b =>
                {
                    b.HasOne("ModeloRelacionamentos.Domain.Dominio.Cursos", "Cursos")
                        .WithMany("CursosPessoa")
                        .HasForeignKey("CodCursos")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ModeloRelacionamentos.Domain.Dominio.Pessoa", "Pessoa")
                        .WithMany("CursosPessoa")
                        .HasForeignKey("CodPessoa")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Endereco", b =>
                {
                    b.HasOne("ModeloRelacionamentos.Domain.Dominio.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("ModeloRelacionamentos.Domain.Dominio.Endereco", "CodigoPessoa")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ModeloRelacionamentos.Domain.Dominio.Filhos", b =>
                {
                    b.HasOne("ModeloRelacionamentos.Domain.Dominio.Pessoa", "Pai")
                        .WithMany("Filhos")
                        .HasForeignKey("CodigoPai")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}