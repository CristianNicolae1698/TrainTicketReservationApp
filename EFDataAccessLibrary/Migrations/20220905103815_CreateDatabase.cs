using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrainTickets.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationOrder = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trains_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trains_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BookingId",
                table: "Clients",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BookingId",
                table: "Routes",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteId",
                table: "Stations",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_BookingId",
                table: "Trains",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_RouteId",
                table: "Trains",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
