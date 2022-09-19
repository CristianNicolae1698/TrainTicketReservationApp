﻿// <auto-generated />
using EFDataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrainTickets.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20220905103815_CreateDatabase")]
    partial class CreateDatabase
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

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

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

            modelBuilder.Entity("BookTrainTickets.Models.Station", b =>
                {
                    b.HasOne("BookTrainTickets.Models.Route", null)
                        .WithMany("Stations")
                        .HasForeignKey("RouteId");
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

            modelBuilder.Entity("BookTrainTickets.Models.Booking", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Routes");

                    b.Navigation("Trains");
                });

            modelBuilder.Entity("BookTrainTickets.Models.Route", b =>
                {
                    b.Navigation("Stations");

                    b.Navigation("Trains");
                });
#pragma warning restore 612, 618
        }
    }
}
