﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VivaCityWebApi.DataAccess;

#nullable disable

namespace VivaCityWebApi.DataAccess.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20240620124105_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("batiment_id_seq");

            modelBuilder.HasSequence("cout_id_seq");

            modelBuilder.HasSequence("ressource_id_seq");

            modelBuilder.HasSequence("ressource_item_id_seq");

            modelBuilder.HasSequence("user_id_seq");

            modelBuilder.HasSequence("village_id_seq");

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.BatimentDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('batiment_id_seq')");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("coutId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("coutId");

                    b.ToTable("Batiments");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.CoutDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('cout_id_seq')");

                    b.Property<int>("Nbr")
                        .HasColumnType("integer");

                    b.Property<int>("RessourceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RessourceId");

                    b.ToTable("Couts");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.RessourceDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('ressource_id_seq')");

                    b.Property<double>("Max")
                        .HasColumnType("double precision");

                    b.Property<double>("Nbr")
                        .HasColumnType("double precision");

                    b.Property<int>("RessourceItemId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserDaoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RessourceItemId");

                    b.HasIndex("UserDaoId");

                    b.ToTable("Ressources");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.RessourceItemDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('ressource_item_id_seq')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RessourceItem");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.UserDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('user_id_seq')");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Scores")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.VillageDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('village_id_seq')");

                    b.Property<int?>("UserDaoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserDaoId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.BatimentDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.CoutDao", "cout")
                        .WithMany()
                        .HasForeignKey("coutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cout");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.CoutDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.RessourceDao", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.RessourceDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.RessourceItemDao", "RessourceItem")
                        .WithMany()
                        .HasForeignKey("RessourceItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VivaCityWebApi.Common.DAO.UserDao", null)
                        .WithMany("Ressources")
                        .HasForeignKey("UserDaoId");

                    b.Navigation("RessourceItem");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.VillageDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.UserDao", null)
                        .WithMany("Villages")
                        .HasForeignKey("UserDaoId");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.UserDao", b =>
                {
                    b.Navigation("Ressources");

                    b.Navigation("Villages");
                });
#pragma warning restore 612, 618
        }
    }
}
