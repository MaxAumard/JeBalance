﻿// <auto-generated />
using System;
using JeBalance.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240123205744_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("JeBalance.Infrastructure.SQLite.Model.DenonciationSQL", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Country");

                    b.Property<int>("Crime")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Crime");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("Date");

                    b.Property<string>("Informant")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Informant");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Response");

                    b.Property<string>("Suspect")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Suspect");

                    b.HasKey("Id");

                    b.ToTable("Denonciation", "app");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.SQLite.Model.PersonneSQL", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Prenom");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsBanned");

                    b.Property<bool>("IsVIP")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsVIP");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nom");

                    b.HasKey("Id");

                    b.ToTable("PERSONNES", "app");
                });
#pragma warning restore 612, 618
        }
    }
}