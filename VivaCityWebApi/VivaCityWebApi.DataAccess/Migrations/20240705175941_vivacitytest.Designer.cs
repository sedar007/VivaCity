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
    [Migration("20240705175941_vivacitytest")]
    partial class vivacitytest
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

                    b.Property<int?>("CoutId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int?>("VillageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoutId");

                    b.HasIndex("VillageId");

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

                    b.Property<int?>("RessourceId")
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

                    b.Property<int>("Max")
                        .HasColumnType("integer");

                    b.Property<int>("Nbr")
                        .HasColumnType("integer");

                    b.Property<int?>("RessourceItemId")
                        .HasColumnType("integer");

                    b.Property<int?>("VillageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RessourceItemId");

                    b.HasIndex("VillageId");

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

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.BatimentDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.CoutDao", "Cout")
                        .WithMany()
                        .HasForeignKey("CoutId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VivaCityWebApi.Common.DAO.VillageDao", "Village")
                        .WithMany("Batiments")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cout");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.CoutDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.RessourceDao", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.RessourceDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.RessourceItemDao", "RessourceItem")
                        .WithMany()
                        .HasForeignKey("RessourceItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VivaCityWebApi.Common.DAO.VillageDao", null)
                        .WithMany("Ressources")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("RessourceItem");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.VillageDao", b =>
                {
                    b.HasOne("VivaCityWebApi.Common.DAO.UserDao", "User")
                        .WithMany("Villages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.UserDao", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("VivaCityWebApi.Common.DAO.VillageDao", b =>
                {
                    b.Navigation("Batiments");

                    b.Navigation("Ressources");
                });
#pragma warning restore 612, 618
        }
    }
}
