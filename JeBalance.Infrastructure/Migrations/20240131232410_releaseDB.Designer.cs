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
    [Migration("20240131232410_releaseDB")]
    partial class releaseDB
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

                    b.Property<string>("InformantId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("fk_Informant");

                    b.Property<string>("Response")
                        .HasColumnType("TEXT")
                        .HasColumnName("Response");

                    b.Property<string>("SuspectId")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("fk_Suspect");

                    b.HasKey("Id");

                    b.HasIndex("InformantId");

                    b.HasIndex("SuspectId");

                    b.ToTable("DENONCIATION", "app");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.SQLite.Model.PersonSQL", b =>
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

                    b.ToTable("PERSON", "app");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.SQLite.Model.DenonciationSQL", b =>
                {
                    b.HasOne("JeBalance.Infrastructure.SQLite.Model.PersonSQL", "Informant")
                        .WithMany()
                        .HasForeignKey("InformantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JeBalance.Infrastructure.SQLite.Model.PersonSQL", "Suspect")
                        .WithMany()
                        .HasForeignKey("SuspectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Informant");

                    b.Navigation("Suspect");
                });
#pragma warning restore 612, 618
        }
    }
}