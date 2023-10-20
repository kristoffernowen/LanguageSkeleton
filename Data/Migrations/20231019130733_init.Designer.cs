﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20231019130733_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Models.Words.Noun", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BaseForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NounArticle")
                        .HasColumnType("int");

                    b.Property<int>("NounDeclension")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nouns");
                });

            modelBuilder.Entity("Core.Models.Words.Verb", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Infinitive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VerbConjugation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Verbs");
                });
#pragma warning restore 612, 618
        }
    }
}
