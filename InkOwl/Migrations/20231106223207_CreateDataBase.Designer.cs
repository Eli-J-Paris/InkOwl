﻿// <auto-generated />
using System;
using InkOwl.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InkOwl.Migrations
{
    [DbContext(typeof(InkOwlContext))]
    [Migration("20231106223207_CreateDataBase")]
    partial class CreateDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InkOwl.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("NestId")
                        .HasColumnType("integer")
                        .HasColumnName("nest_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_articles");

                    b.HasIndex("NestId")
                        .HasDatabaseName("ix_articles_nest_id");

                    b.ToTable("articles", (string)null);
                });

            modelBuilder.Entity("InkOwl.Models.LogTracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_log_trackers");

                    b.ToTable("log_trackers", (string)null);
                });

            modelBuilder.Entity("InkOwl.Models.Nest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_nests");

                    b.ToTable("nests", (string)null);
                });

            modelBuilder.Entity("InkOwl.Models.TextDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("NestId")
                        .HasColumnType("integer")
                        .HasColumnName("nest_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_text_docs");

                    b.HasIndex("NestId")
                        .HasDatabaseName("ix_text_docs_nest_id");

                    b.ToTable("text_docs", (string)null);
                });

            modelBuilder.Entity("InkOwl.Models.Article", b =>
                {
                    b.HasOne("InkOwl.Models.Nest", null)
                        .WithMany("Articles")
                        .HasForeignKey("NestId")
                        .HasConstraintName("fk_articles_nests_nest_id");
                });

            modelBuilder.Entity("InkOwl.Models.TextDoc", b =>
                {
                    b.HasOne("InkOwl.Models.Nest", null)
                        .WithMany("Notes")
                        .HasForeignKey("NestId")
                        .HasConstraintName("fk_text_docs_nests_nest_id");
                });

            modelBuilder.Entity("InkOwl.Models.Nest", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}