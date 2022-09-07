﻿// <auto-generated />
using System;
using BookTrainTickets.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookTrainTickets.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20220907125008_AddRouteStations")]
    partial class AddRouteStations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookTrainTickets.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookingDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CheckedIn")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StationOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Train", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrainNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("RouteId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("RouteStation", b =>
                {
                    b.Property<Guid>("RoutesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoutesId", "StationsId");

                    b.HasIndex("StationsId");

                    b.ToTable("RouteStation");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Client", b =>
                {
                    b.HasOne("BookTrainTickets.Models.Booking", null)
                        .WithMany("Clients")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Route", b =>
                {
                    b.HasOne("BookTrainTickets.Models.Booking", null)
                        .WithMany("Routes")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Train", b =>
                {
                    b.HasOne("BookTrainTickets.Models.Booking", null)
                        .WithMany("Trains")
                        .HasForeignKey("BookingId");

                    b.HasOne("BookTrainTickets.Models.Route", null)
                        .WithMany("Trains")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("RouteStation", b =>
                {
                    b.HasOne("BookTrainTickets.Models.Route", null)
                        .WithMany()
                        .HasForeignKey("RoutesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTrainTickets.Models.Station", null)
                        .WithMany()
                        .HasForeignKey("StationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTrainTickets.Models.Booking", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Routes");

                    b.Navigation("Trains");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Route", b =>
                {
                    b.Navigation("Trains");
                });
#pragma warning restore 612, 618
        }
    }
}