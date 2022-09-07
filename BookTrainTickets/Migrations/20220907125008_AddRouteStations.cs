using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrainTickets.Migrations
{
    public partial class AddRouteStations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_RouteId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Stations");

            migrationBuilder.CreateTable(
                name: "RouteStation",
                columns: table => new
                {
                    RoutesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStation", x => new { x.RoutesId, x.StationsId });
                    table.ForeignKey(
                        name: "FK_RouteStation_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStation_Stations_StationsId",
                        column: x => x.StationsId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_StationsId",
                table: "RouteStation",
                column: "StationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteStation");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Stations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteId",
                table: "Stations",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Routes_RouteId",
                table: "Stations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
