﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using amanydb.classes;

#nullable disable

namespace amanydb.Migrations
{
    [DbContext(typeof(db))]
    [Migration("20230501190030_dahsdhg")]
    partial class dahsdhg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("amanydb.classes.Searchrecord", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<string>("word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("searchrecord");
                });

            modelBuilder.Entity("amanydb.classes.file", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("recordid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("recordid");

                    b.ToTable("file");
                });

            modelBuilder.Entity("amanydb.classes.file", b =>
                {
                    b.HasOne("amanydb.classes.Searchrecord", "record")
                        .WithMany()
                        .HasForeignKey("recordid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("record");
                });
#pragma warning restore 612, 618
        }
    }
}
