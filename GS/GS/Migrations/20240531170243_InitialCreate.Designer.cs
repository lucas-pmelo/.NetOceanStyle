﻿// <auto-generated />
using GS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace GS.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240531170243_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GS.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("GS_Cidade");
                });

            modelBuilder.Entity("GS.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.HasKey("Id");

                    b.ToTable("GS_Empresa");
                });

            modelBuilder.Entity("GS.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.Property<int>("CidadeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Numero")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("GS_Endereco");
                });

            modelBuilder.Entity("GS.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("Id");

                    b.ToTable("GS_Estado");
                });

            modelBuilder.Entity("GS.Models.Inspetor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Especializacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)");

                    b.HasKey("Id");

                    b.ToTable("GS_Inspetor");
                });

            modelBuilder.Entity("GS.Models.InspetoresVistorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InspetorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("VistoriaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("InspetorId");

                    b.HasIndex("VistoriaId");

                    b.ToTable("GS_Inspetores_Vistorias");
                });

            modelBuilder.Entity("GS.Models.Veiculo", b =>
                {
                    b.Property<int>("Tie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Tie"));

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("LinkImagem")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<int>("Sonar")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("TipoMotor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("Tie");

                    b.HasIndex("EmpresaId");

                    b.ToTable("GS_Veiculo");
                });

            modelBuilder.Entity("GS.Models.Vistoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<int>("NivelRuido")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("GS_Vistoria");
                });

            modelBuilder.Entity("GS.Models.Cidade", b =>
                {
                    b.HasOne("GS.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("GS.Models.Endereco", b =>
                {
                    b.HasOne("GS.Models.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GS.Models.Empresa", "Empresa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("GS.Models.InspetoresVistorias", b =>
                {
                    b.HasOne("GS.Models.Inspetor", "Inspetor")
                        .WithMany("InspetoresVistorias")
                        .HasForeignKey("InspetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GS.Models.Vistoria", "Vistoria")
                        .WithMany("InspetoresVistorias")
                        .HasForeignKey("VistoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inspetor");

                    b.Navigation("Vistoria");
                });

            modelBuilder.Entity("GS.Models.Veiculo", b =>
                {
                    b.HasOne("GS.Models.Empresa", "Empresa")
                        .WithMany("Veiculos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("GS.Models.Vistoria", b =>
                {
                    b.HasOne("GS.Models.Veiculo", "Veiculo")
                        .WithMany("Vistorias")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("GS.Models.Cidade", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("GS.Models.Empresa", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("GS.Models.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("GS.Models.Inspetor", b =>
                {
                    b.Navigation("InspetoresVistorias");
                });

            modelBuilder.Entity("GS.Models.Veiculo", b =>
                {
                    b.Navigation("Vistorias");
                });

            modelBuilder.Entity("GS.Models.Vistoria", b =>
                {
                    b.Navigation("InspetoresVistorias");
                });
#pragma warning restore 612, 618
        }
    }
}