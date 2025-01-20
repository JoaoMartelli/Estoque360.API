﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciarEstoque.Repositorio.Migrations
{
    [DbContext(typeof(GerenciarEstoqueContexto))]
    [Migration("20241109173154_versao2")]
    partial class versao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoriaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Nome");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProdutoID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("Preco")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("Preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Categoria", b =>
                {
                    b.HasOne("GerenciarEstoque.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Categorias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("GerenciarEstoque.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("GerenciarEstoque.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
