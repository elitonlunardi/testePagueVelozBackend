﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagueVeloz.Teste.Infra.Data;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    [DbContext(typeof(PagueVelozContext))]
    [Migration("20191110041137_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NomeFantasia")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnName("Uf")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("DateTime");

                    b.Property<string>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("IdEmpresa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("VarChar")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Empresa", b =>
                {
                    b.OwnsOne("PagueVeloz.Teste.Domain.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Cnpj")
                                .HasColumnType("varchar(14)")
                                .HasMaxLength(14);

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresa");

                            b1.HasOne("PagueVeloz.Teste.Domain.Empresa")
                                .WithOne("Cnpj")
                                .HasForeignKey("PagueVeloz.Teste.Domain.Cnpj", "EmpresaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Fornecedor", b =>
                {
                    b.HasOne("PagueVeloz.Teste.Domain.Empresa", "Empresa")
                        .WithMany("Fornecedores")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("PagueVeloz.Teste.Domain.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Documento")
                                .HasColumnType("VarChar")
                                .HasMaxLength(15);

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.HasOne("PagueVeloz.Teste.Domain.Fornecedor")
                                .WithOne("Documento")
                                .HasForeignKey("PagueVeloz.Teste.Domain.Documento", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("PagueVeloz.Teste.Domain.Rg", "Rg", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId");

                            b1.Property<string>("Value")
                                .HasColumnName("Rg")
                                .HasColumnType("VarChar")
                                .HasMaxLength(10);

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.HasOne("PagueVeloz.Teste.Domain.Fornecedor")
                                .WithOne("Rg")
                                .HasForeignKey("PagueVeloz.Teste.Domain.Rg", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
