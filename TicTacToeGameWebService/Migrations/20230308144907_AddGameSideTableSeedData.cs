using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicTacToeGameWebService.Migrations
{
    /// <inheritdoc />
    public partial class AddGameSideTableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "game_side",
                columns: new[] { "id", "create_date", "side_name", "status_id", "update_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(1691), "Crosses", 1, new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(1706) },
                    { 2, new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(1709), "Noughts", 1, new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(1710) }
                });

            migrationBuilder.UpdateData(
                table: "game_status",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(5268), new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(5278) });

            migrationBuilder.UpdateData(
                table: "game_status",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(5281), new DateTime(2023, 3, 8, 17, 49, 6, 822, DateTimeKind.Local).AddTicks(5283) });

            migrationBuilder.UpdateData(
                table: "status",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 17, 49, 6, 824, DateTimeKind.Local).AddTicks(4388), new DateTime(2023, 3, 8, 17, 49, 6, 824, DateTimeKind.Local).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "status",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 17, 49, 6, 824, DateTimeKind.Local).AddTicks(4407), new DateTime(2023, 3, 8, 17, 49, 6, 824, DateTimeKind.Local).AddTicks(4408) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "game_side",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "game_side",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "game_status",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3137), new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "game_status",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3150), new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "status",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2369), new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2374) });

            migrationBuilder.UpdateData(
                table: "status",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_date", "update_date" },
                values: new object[] { new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2376), new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2377) });
        }
    }
}
