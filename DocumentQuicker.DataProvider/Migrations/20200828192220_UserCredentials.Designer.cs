﻿// <auto-generated />
using System;
using DocumentQuicker.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentQuicker.DataProvider.Migrations
{
    [DbContext(typeof(DocumentQuickerContext))]
    [Migration("20200828192220_UserCredentials")]
    partial class UserCredentials
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.AddressEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RawAddress")
                        .HasColumnType("text");

                    b.Property<byte[]>("RequisiteId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("RequisiteId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

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

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.BankDetailsEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<byte[]>("BankInfoId")
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("RequisiteId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("BankInfoId");

                    b.HasIndex("RequisiteId")
                        .IsUnique();

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.BankInfoEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("BankDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Bic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorrAccount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BankInfos");
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.RequisiteEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

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

                    b.HasKey("Id");

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

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.AddressEf", b =>
                {
                    b.HasOne("DocumentQuicker.DataProvider.Models.RequisiteEf", "Requisite")
                        .WithOne("Address")
                        .HasForeignKey("DocumentQuicker.DataProvider.Models.AddressEf", "RequisiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.BankDetailsEf", b =>
                {
                    b.HasOne("DocumentQuicker.DataProvider.Models.BankInfoEf", "BankInfo")
                        .WithMany()
                        .HasForeignKey("BankInfoId");

                    b.HasOne("DocumentQuicker.DataProvider.Models.RequisiteEf", "Requisite")
                        .WithOne("BankDetails")
                        .HasForeignKey("DocumentQuicker.DataProvider.Models.BankDetailsEf", "RequisiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
