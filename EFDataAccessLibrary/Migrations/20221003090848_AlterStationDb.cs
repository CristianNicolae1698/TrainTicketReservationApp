using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTrainTickets.Migrations
{
    public partial class AlterStationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "StationName" },
                values: new object[] { new Guid("c71953f2-3cdb-4000-bc95-c6297c1b61da"), "Ciolpani" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "StationName" },
                values: new object[] { new Guid("cdb933ba-cae1-44b7-b785-4bfbfce4549e"), "Pipera" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c71953f2-3cdb-4000-bc95-c6297c1b61da"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("cdb933ba-cae1-44b7-b785-4bfbfce4549e"));
        }
    }
}
