﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projecto_autismo.InfraStructure.DataBase;

#nullable disable

namespace projecto_autismo.Migrations
{
    [DbContext(typeof(DbConnection))]
    partial class DbConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("projecto_autismo.Domain.AlunoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("EncarregadoEntityid")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("deficiencia")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("tipo_deficiencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("EncarregadoEntityid");

                    b.ToTable("aluno");
                });

            modelBuilder.Entity("projecto_autismo.Domain.AnoLectivoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("anoLectivo");
                });

            modelBuilder.Entity("projecto_autismo.Domain.BibliotecaVirtualEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CategoriaEntityid")
                        .HasColumnType("int");

                    b.Property<int?>("FuncionarioEntityid")
                        .HasColumnType("int");

                    b.Property<int>("categoriaId")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("int");

                    b.Property<string>("media")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("CategoriaEntityid");

                    b.HasIndex("FuncionarioEntityid");

                    b.ToTable("bVirtual");
                });

            modelBuilder.Entity("projecto_autismo.Domain.CargoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("cargo");
                });

            modelBuilder.Entity("projecto_autismo.Domain.CategoriaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("projecto_autismo.Domain.DisciplinaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("TurmaEntityid")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("TurmaEntityid");

                    b.ToTable("disciplina");
                });

            modelBuilder.Entity("projecto_autismo.Domain.EncarregadoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("encarregado");
                });

            modelBuilder.Entity("projecto_autismo.Domain.FuncionarioEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("funcao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("num_identificacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("projecto_autismo.Domain.MatriculaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("alunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("matricula");
                });

            modelBuilder.Entity("projecto_autismo.Domain.NotaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("alunoId")
                        .HasColumnType("int");

                    b.Property<int>("disciplinaId")
                        .HasColumnType("int");

                    b.Property<float>("nota1")
                        .HasColumnType("float");

                    b.Property<float>("nota2")
                        .HasColumnType("float");

                    b.Property<float>("nota3")
                        .HasColumnType("float");

                    b.Property<int>("trimestreId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("disciplinaId");

                    b.ToTable("nota");
                });

            modelBuilder.Entity("projecto_autismo.Domain.TesteEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.Property<int>("parcela")
                        .HasColumnType("int");

                    b.Property<string>("semestre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("teste");
                });

            modelBuilder.Entity("projecto_autismo.Domain.TrimestreEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("anoLectivoId")
                        .HasColumnType("int");

                    b.Property<int>("trimestre")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("trimestre");
                });

            modelBuilder.Entity("projecto_autismo.Domain.TurmaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("turno")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("turma");
                });

            modelBuilder.Entity("projecto_autismo.Domain.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cargoId")
                        .HasColumnType("int");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("cargoId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("projecto_autismo.Domain.VitrineEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("funcionarioId");

                    b.ToTable("vitrine");
                });

            modelBuilder.Entity("projecto_autismo.Domain.AlunoEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.EncarregadoEntity", null)
                        .WithMany("alunos")
                        .HasForeignKey("EncarregadoEntityid");
                });

            modelBuilder.Entity("projecto_autismo.Domain.BibliotecaVirtualEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.CategoriaEntity", null)
                        .WithMany("virtuais")
                        .HasForeignKey("CategoriaEntityid");

                    b.HasOne("projecto_autismo.Domain.FuncionarioEntity", null)
                        .WithMany("virtuais")
                        .HasForeignKey("FuncionarioEntityid");
                });

            modelBuilder.Entity("projecto_autismo.Domain.DisciplinaEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.TurmaEntity", null)
                        .WithMany("disciplinas")
                        .HasForeignKey("TurmaEntityid");
                });

            modelBuilder.Entity("projecto_autismo.Domain.NotaEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.DisciplinaEntity", "disciplina")
                        .WithMany()
                        .HasForeignKey("disciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("disciplina");
                });

            modelBuilder.Entity("projecto_autismo.Domain.UserEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.CargoEntity", "cargo")
                        .WithMany()
                        .HasForeignKey("cargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cargo");
                });

            modelBuilder.Entity("projecto_autismo.Domain.VitrineEntity", b =>
                {
                    b.HasOne("projecto_autismo.Domain.FuncionarioEntity", "funcionario")
                        .WithMany("vitrines")
                        .HasForeignKey("funcionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("funcionario");
                });

            modelBuilder.Entity("projecto_autismo.Domain.CategoriaEntity", b =>
                {
                    b.Navigation("virtuais");
                });

            modelBuilder.Entity("projecto_autismo.Domain.EncarregadoEntity", b =>
                {
                    b.Navigation("alunos");
                });

            modelBuilder.Entity("projecto_autismo.Domain.FuncionarioEntity", b =>
                {
                    b.Navigation("virtuais");

                    b.Navigation("vitrines");
                });

            modelBuilder.Entity("projecto_autismo.Domain.TurmaEntity", b =>
                {
                    b.Navigation("disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
