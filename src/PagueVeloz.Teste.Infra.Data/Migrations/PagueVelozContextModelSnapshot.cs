﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PagueVeloz.Teste.Infra.Data;

namespace PagueVeloz.Teste.Infra.Data.Migrations
{
    [DbContext(typeof(PagueVelozContext))]
    partial class PagueVelozContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("IdEmpresa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Telefone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IdFornecedor");

                    b.Property<string>("Numero");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Empresa", b =>
                {
                    b.OwnsOne("PagueVeloz.Teste.Domain.Cnpj", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("EmpresaId");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Cnpj")
                                .HasColumnType("varchar(19)")
                                .HasMaxLength(19);

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

                    b.OwnsOne("PagueVeloz.Teste.Domain.DataNascimento", "DataNascimento", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId");

                            b1.Property<DateTime>("Value")
                                .HasColumnName("DataNascimento")
                                .HasColumnType("DateTime2");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.HasOne("PagueVeloz.Teste.Domain.Fornecedor")
                                .WithOne("DataNascimento")
                                .HasForeignKey("PagueVeloz.Teste.Domain.DataNascimento", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("PagueVeloz.Teste.Domain.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("FornecedorId");

                            b1.Property<short>("TipoPessoa")
                                .HasColumnName("TipoPessoa")
                                .HasColumnType("smallint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Documento")
                                .HasColumnType("varchar(20)")
                                .HasMaxLength(20);

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
                                .HasColumnType("varchar(10)")
                                .HasMaxLength(10);

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedor");

                            b1.HasOne("PagueVeloz.Teste.Domain.Fornecedor")
                                .WithOne("Rg")
                                .HasForeignKey("PagueVeloz.Teste.Domain.Rg", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("PagueVeloz.Teste.Domain.Telefone", b =>
                {
                    b.HasOne("PagueVeloz.Teste.Domain.Fornecedor", "Fornecedor")
                        .WithMany("Telefones")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
