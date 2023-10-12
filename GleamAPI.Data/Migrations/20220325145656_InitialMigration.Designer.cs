﻿// <auto-generated />
using System;
using GleamAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GleamAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220325145656_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GleamAPI.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GleamVenueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReviewersEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GleamVenueId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GleamAPI.Entities.Venue.GleamVenue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");                  

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GleamVenues");
                });

            modelBuilder.Entity("GleamAPI.Entities.Review", b =>
                {
                    b.HasOne("GleamAPI.Entities.Venue.GleamVenue", "GleamVenue")
                        .WithMany("Reviews")
                        .HasForeignKey("GleamVenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GleamVenue");
                });

            modelBuilder.Entity("GleamAPI.Entities.Venue.GleamVenue", b =>
                {
                    b.OwnsOne("GleamAPI.Data.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("GleamVenueId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Street");

                            b1.HasKey("GleamVenueId");

                            b1.ToTable("GleamVenues");

                            b1.WithOwner()
                                .HasForeignKey("GleamVenueId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("GleamAPI.Entities.Venue.GleamVenue", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}