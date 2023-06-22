﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.db;

#nullable disable

namespace GerenciadorVendas.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JRJ.Modas.CategoriaModel", b =>
                {
                    b.Property<long?>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid>("CategoriaIDGUID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("JRJ.Modas.ClienteModel", b =>
                {
                    b.Property<long?>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<Guid>("ClienteIDGUID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("JRJ.Modas.PedidoModel", b =>
                {
                    b.Property<long?>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteModelID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PedidoIDGUID")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PedidoID");

                    b.HasIndex("ClienteModelID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("JRJ.Modas.PedidoProdutoModel", b =>
                {
                    b.Property<long?>("PedidoProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("PedidoModelPedidoID")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoID")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoProdutoID");

                    b.HasIndex("PedidoModelPedidoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("PedidosProdutos");
                });

            modelBuilder.Entity("JRJ.Modas.ProdutoModel", b =>
                {
                    b.Property<long?>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CategoriaID")
                        .HasColumnType("bigint");

                    b.Property<long>("Estoque")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<Guid>("ProdutoIDGUID")
                        .HasColumnType("char(36)");

                    b.HasKey("ProdutoID");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("JRJ.Modas.PedidoModel", b =>
                {
                    b.HasOne("JRJ.Modas.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("JRJ.Modas.PedidoProdutoModel", b =>
                {
                    b.HasOne("JRJ.Modas.PedidoModel", null)
                        .WithMany("ProdutosPedido")
                        .HasForeignKey("PedidoModelPedidoID");

                    b.HasOne("JRJ.Modas.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("JRJ.Modas.ProdutoModel", b =>
                {
                    b.HasOne("JRJ.Modas.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("JRJ.Modas.PedidoModel", b =>
                {
                    b.Navigation("ProdutosPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
