﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreeFactoryDatabaseImplement;

namespace TreeFactoryDatabaseImplement.Migrations
{
    [DbContext(typeof(TreeFactoryDatabase))]
    [Migration("20210314200223_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CannedId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CannedId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.Wood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Woods");
                });

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.WoodComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CannedId")
                        .HasColumnType("int");

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CannedId");

                    b.HasIndex("ComponentId");

                    b.ToTable("WoodComponents");
                });

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("TreeFactoryDatabaseImplement.Models.Wood", "Wood")
                        .WithMany("Order")
                        .HasForeignKey("CannedId");
                });

            modelBuilder.Entity("TreeFactoryDatabaseImplement.Models.WoodComponent", b =>
                {
                    b.HasOne("TreeFactoryDatabaseImplement.Models.Wood", "Wood")
                        .WithMany("WoodComponents")
                        .HasForeignKey("CannedId");

                    b.HasOne("TreeFactoryDatabaseImplement.Models.Component", "Component")
                        .WithMany("WoodComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
