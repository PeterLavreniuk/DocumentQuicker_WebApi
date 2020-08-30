﻿// <auto-generated />
using System;
using DocumentQuicker.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentQuicker.DataProvider.Migrations
{
    [DbContext(typeof(DocumentQuickerContext))]
    partial class DocumentQuickerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.AuditEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<DateTime>("AuditDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("ItemId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DatabaseAudits");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.BankEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Bic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorrAccount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.RequisiteEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("BankAccount")
                        .HasColumnType("text");

                    b.Property<byte[]>("BankId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<string>("INN")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("KPP")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RawAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Requisites");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.UserCredentialsEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.UserProfileEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.RequisiteEf", b =>
                {
                    b.HasOne("DocumentQuicker.DataProvider.Models.BankEf", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
