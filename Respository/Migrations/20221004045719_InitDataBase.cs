using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRoot = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersRols",
                schema: "Security",
                columns: table => new
                {
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersRols", x => new { x.RolId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayersRols_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersRols_Rols_RolId",
                        column: x => x.RolId,
                        principalSchema: "Security",
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolsActivity",
                schema: "Security",
                columns: table => new
                {
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolsActivity", x => new { x.RolId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_RolsActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "Security",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolsActivity_Rols_RolId",
                        column: x => x.RolId,
                        principalSchema: "Security",
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quinielas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quinielas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quinielas_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalGoals = table.Column<int>(type: "int", nullable: false),
                    VisitorGoals = table.Column<int>(type: "int", nullable: false),
                    CanDraw = table.Column<bool>(type: "bit", nullable: false),
                    VisitorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuinielaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchGames_Quinielas_QuinielaId",
                        column: x => x.QuinielaId,
                        principalTable: "Quinielas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchGames_Teams_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchGames_Teams_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchResult",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchGameId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchResult", x => new { x.PlayerId, x.MatchGameId });
                    table.ForeignKey(
                        name: "FK_PlayerMatchResult_MatchGames_MatchGameId",
                        column: x => x.MatchGameId,
                        principalTable: "MatchGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatchResult_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Activities",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { "Index", "Watch Index" },
                    { "UpdateMatches", "Update matches" },
                    { "UpdateQuiniela", "Update Quiniela matches" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ftrejo" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Rols",
                columns: new[] { "Id", "Description", "IsRoot" },
                values: new object[,]
                {
                    { "Admin", "Root admin", true },
                    { "Player", "Single PLayer", false }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "ARG", "Argentina" },
                    { "AUS", "Australia" },
                    { "BEL", "Belgica" },
                    { "BRA", "Brasil" },
                    { "CAN", "Canada" },
                    { "CMR", "Camerun" },
                    { "CRC", "CostaRica" },
                    { "CRO", "Croacia" },
                    { "DEN", "Dinamarca" },
                    { "ECU", "Ecuador" },
                    { "ENG", "Inglaterra" },
                    { "ESP", "España" },
                    { "FRA", "Francia" },
                    { "GER", "Alemania" },
                    { "GHA", "Ghana" },
                    { "IRN", "Iran" },
                    { "JPN", "Japon" },
                    { "KOR", "Corea del Sur" },
                    { "KSA", "Arabia Saudita" },
                    { "MAR", "Marruecos" },
                    { "MEX", "Mexico" },
                    { "NED", "Paises Bajos" },
                    { "POL", "Polonia" },
                    { "POR", "Portugal" },
                    { "QAT", "Catar" },
                    { "SEN", "Senegal" },
                    { "SRB", "Serbia" },
                    { "SUI", "Suiza" },
                    { "TUN", "Tunez" },
                    { "URU", "Uruguay" },
                    { "USA", "Estados Unidos" },
                    { "WAL", "Gales" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Qatar 2022" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "PlayersRols",
                columns: new[] { "PlayerId", "RolId" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Quinielas",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "TournamentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 1", new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 2", new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 3", new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolsActivity",
                columns: new[] { "ActivityId", "RolId" },
                values: new object[,]
                {
                    { "Index", "Admin" },
                    { "UpdateMatches", "Admin" },
                    { "UpdateQuiniela", "Admin" },
                    { "UpdateQuiniela", "Player" }
                });

            migrationBuilder.InsertData(
                table: "MatchGames",
                columns: new[] { "Id", "CanDraw", "Date", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 0, "QAT", 1, 0, "ECU" },
                    { 2, true, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 0, "SEN", 1, 0, "NED" },
                    { 3, true, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 0, "ENG", 1, 0, "IRN" },
                    { 4, true, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 0, "USA", 1, 0, "WAL" },
                    { 5, true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "C", 0, "ARG", 1, 0, "KSA" },
                    { 6, true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "C", 0, "MEX", 1, 0, "POL" },
                    { 7, true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "D", 0, "DEN", 1, 0, "TUN" },
                    { 8, true, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "D", 0, "FRA", 1, 0, "AUS" },
                    { 9, true, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 0, "ESP", 1, 0, "CRC" },
                    { 10, true, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "E", 0, "GER", 1, 0, "JPN" },
                    { 11, true, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", 0, "BEL", 1, 0, "CAN" },
                    { 12, true, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "F", 0, "MAR", 1, 0, "CRO" },
                    { 13, true, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "G", 0, "SUI", 1, 0, "CMR" },
                    { 14, true, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "G", 0, "BRA", 1, 0, "SRB" },
                    { 15, true, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "H", 0, "POR", 1, 0, "GHA" },
                    { 16, true, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "H", 0, "URU", 1, 0, "KOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchGames_LocalId",
                table: "MatchGames",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGames_QuinielaId",
                table: "MatchGames",
                column: "QuinielaId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchGames_VisitorId",
                table: "MatchGames",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResult_MatchGameId",
                table: "PlayerMatchResult",
                column: "MatchGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersRols_PlayerId",
                schema: "Security",
                table: "PlayersRols",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_TournamentId",
                table: "Quinielas",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolsActivity_ActivityId",
                schema: "Security",
                table: "RolsActivity",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMatchResult");

            migrationBuilder.DropTable(
                name: "PlayersRols",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "RolsActivity",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "MatchGames");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rols",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Quinielas");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
