using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicTacToeGameWebService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_side",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    side_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_side", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_side_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "game_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    game_status_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_status_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    game_status_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    crosses_player_id = table.Column<int>(type: "int", nullable: false),
                    noughts_player_id = table.Column<int>(type: "int", nullable: false),
                    winner_player_id = table.Column<int>(type: "int", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_game_status",
                        column: x => x.game_status_id,
                        principalTable: "game_status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_game_player",
                        column: x => x.crosses_player_id,
                        principalTable: "player",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_game_player1",
                        column: x => x.noughts_player_id,
                        principalTable: "player",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_game_player2",
                        column: x => x.winner_player_id,
                        principalTable: "player",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_game_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "point",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x_value = table.Column<int>(type: "int", nullable: false),
                    y_value = table.Column<int>(type: "int", nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    game_side_id = table.Column<int>(type: "int", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point", x => x.id);
                    table.ForeignKey(
                        name: "FK_point_game",
                        column: x => x.game_id,
                        principalTable: "game",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_point_game_side",
                        column: x => x.game_side_id,
                        principalTable: "game_side",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_point_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "create_date", "status_name", "update_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2369), "Active", new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2374) },
                    { 2, new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2376), "Not active", new DateTime(2023, 3, 8, 13, 33, 31, 471, DateTimeKind.Local).AddTicks(2377) }
                });

            migrationBuilder.InsertData(
                table: "game_status",
                columns: new[] { "id", "create_date", "game_status_name", "status_id", "update_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3137), "Running", 1, new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3148) },
                    { 2, new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3150), "Finished", 1, new DateTime(2023, 3, 8, 13, 33, 31, 470, DateTimeKind.Local).AddTicks(3151) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_crosses_player_id",
                table: "game",
                column: "crosses_player_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_game_status_id",
                table: "game",
                column: "game_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_noughts_player_id",
                table: "game",
                column: "noughts_player_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_status_id",
                table: "game",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_winner_player_id",
                table: "game",
                column: "winner_player_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_side_status_id",
                table: "game_side",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_status_status_id",
                table: "game_status",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_status_id",
                table: "player",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_point_game_id",
                table: "point",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_point_game_side_id",
                table: "point",
                column: "game_side_id");

            migrationBuilder.CreateIndex(
                name: "IX_point_status_id",
                table: "point",
                column: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "point");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "game_side");

            migrationBuilder.DropTable(
                name: "game_status");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}
