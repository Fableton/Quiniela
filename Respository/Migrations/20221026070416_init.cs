using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class init : Migration
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
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuinielaId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ended = table.Column<bool>(type: "bit", nullable: false),
                    LocalGoals = table.Column<int>(type: "int", nullable: false),
                    VisitorGoals = table.Column<int>(type: "int", nullable: false),
                    CanDraw = table.Column<bool>(type: "bit", nullable: false),
                    VisitorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Quinielas_QuinielaId",
                        column: x => x.QuinielaId,
                        principalTable: "Quinielas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuinielaId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ended = table.Column<bool>(type: "bit", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quinielas_QuinielaId",
                        column: x => x.QuinielaId,
                        principalTable: "Quinielas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatchResult_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatchResult_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatchResult_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Activities",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { "AddAdminUsers", "Add new players" },
                    { "GenerateLinkAdminUsers", "Generate acces token to user" },
                    { "Index", "Watch Index" },
                    { "UpdateAdminMatchResult", "Update Match Result" },
                    { "UpdateMatches", "Update matches" },
                    { "UpdateQuiniela", "Update Quiniela matches" },
                    { "ViewAdminMatch", "View List of Matchs" },
                    { "ViewAdminUsers", "View List of Users" }
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
                    { "N/A", "Por definir" },
                    { "NED", "Paises Bajos" },
                    { "POL", "Polonia" },
                    { "POR", "Portugal" },
                    { "QAT", "Catar" },
                    { "SEN", "Senegal" },
                    { "SRB", "Serbia" },
                    { "SUI", "Suiza" },
                    { "TUN", "Tunez" },
                    { "URU", "Uruguay" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { "USA", "Estados Unidos" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { "WAL", "Gales" });

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
                    { 1, new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 1", new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 2", new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jornada 3", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octavos de final", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuartos de final", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Semifinal", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finales", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "RolsActivity",
                columns: new[] { "ActivityId", "RolId" },
                values: new object[,]
                {
                    { "AddAdminUsers", "Admin" },
                    { "GenerateLinkAdminUsers", "Admin" },
                    { "Index", "Admin" },
                    { "UpdateAdminMatchResult", "Admin" },
                    { "UpdateMatches", "Admin" },
                    { "UpdateQuiniela", "Admin" },
                    { "ViewAdminMatch", "Admin" },
                    { "ViewAdminUsers", "Admin" },
                    { "Index", "Player" },
                    { "UpdateQuiniela", "Player" }
                });

            migrationBuilder.InsertData(
                table: "Matchs",
                columns: new[] { "Id", "CanDraw", "Date", "Ended", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 11, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "QAT", 1, 0, "ECU" },
                    { 2, true, new DateTime(2022, 11, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "SEN", 1, 0, "NED" },
                    { 3, true, new DateTime(2022, 11, 21, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "ENG", 1, 0, "IRN" },
                    { 4, true, new DateTime(2022, 11, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "USA", 1, 0, "WAL" },
                    { 5, true, new DateTime(2022, 11, 22, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "ARG", 1, 0, "KSA" },
                    { 6, true, new DateTime(2022, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "MEX", 1, 0, "POL" },
                    { 7, true, new DateTime(2022, 11, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "DEN", 1, 0, "TUN" },
                    { 8, true, new DateTime(2022, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "FRA", 1, 0, "AUS" },
                    { 9, true, new DateTime(2022, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "ESP", 1, 0, "CRC" },
                    { 10, true, new DateTime(2022, 11, 23, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "GER", 1, 0, "JPN" },
                    { 11, true, new DateTime(2022, 11, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "BEL", 1, 0, "CAN" },
                    { 12, true, new DateTime(2022, 11, 23, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "MAR", 1, 0, "CRO" },
                    { 13, true, new DateTime(2022, 11, 24, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "SUI", 1, 0, "CMR" },
                    { 14, true, new DateTime(2022, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "BRA", 1, 0, "SRB" },
                    { 15, true, new DateTime(2022, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "POR", 1, 0, "GHA" },
                    { 16, true, new DateTime(2022, 11, 24, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "URU", 1, 0, "KOR" },
                    { 17, true, new DateTime(2022, 11, 25, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "WAL", 2, 0, "IRN" },
                    { 18, true, new DateTime(2022, 11, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "QAT", 2, 0, "SEN" },
                    { 19, true, new DateTime(2022, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "NED", 2, 0, "ECU" },
                    { 20, true, new DateTime(2022, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "ENG", 2, 0, "USA" },
                    { 21, true, new DateTime(2022, 11, 26, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "TUN", 2, 0, "AUS" },
                    { 22, true, new DateTime(2022, 11, 26, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "POL", 2, 0, "KSA" },
                    { 23, true, new DateTime(2022, 11, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "FRA", 2, 0, "DEN" },
                    { 24, true, new DateTime(2022, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "ARG", 2, 0, "MEX" },
                    { 25, true, new DateTime(2022, 11, 27, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "JPN", 2, 0, "CRC" },
                    { 26, true, new DateTime(2022, 11, 27, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "BEL", 2, 0, "MAR" },
                    { 27, true, new DateTime(2022, 11, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "CRO", 2, 0, "CAN" },
                    { 28, true, new DateTime(2022, 11, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "ESP", 2, 0, "GER" },
                    { 29, true, new DateTime(2022, 11, 28, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "CMR", 2, 0, "SRB" },
                    { 30, true, new DateTime(2022, 11, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "KOR", 2, 0, "GHA" },
                    { 31, true, new DateTime(2022, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "BRA", 2, 0, "SUI" },
                    { 32, true, new DateTime(2022, 11, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "POR", 2, 0, "URU" },
                    { 33, true, new DateTime(2022, 11, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "ECU", 3, 0, "SEN" },
                    { 34, true, new DateTime(2022, 11, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo A", 0, "NED", 3, 0, "QAT" },
                    { 35, true, new DateTime(2022, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "IRN", 3, 0, "USA" },
                    { 36, true, new DateTime(2022, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo B", 0, "WAL", 3, 0, "ENG" },
                    { 37, true, new DateTime(2022, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "TUN", 3, 0, "FRA" },
                    { 38, true, new DateTime(2022, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo D", 0, "AUS", 3, 0, "DEN" },
                    { 39, true, new DateTime(2022, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "POL", 3, 0, "ARG" },
                    { 40, true, new DateTime(2022, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo C", 0, "KSA", 3, 0, "MEX" },
                    { 41, true, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "CRO", 3, 0, "BEL" },
                    { 42, true, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo F", 0, "CAN", 3, 0, "MAR" }
                });

            migrationBuilder.InsertData(
                table: "Matchs",
                columns: new[] { "Id", "CanDraw", "Date", "Ended", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
                    { 43, true, new DateTime(2022, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "JPN", 3, 0, "ESP" },
                    { 44, true, new DateTime(2022, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo E", 0, "CRC", 3, 0, "GER" },
                    { 45, true, new DateTime(2022, 12, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "KOR", 3, 0, "POR" },
                    { 46, true, new DateTime(2022, 12, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo H", 0, "GHA", 3, 0, "URU" },
                    { 47, true, new DateTime(2022, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "SRB", 3, 0, "SUI" },
                    { 48, true, new DateTime(2022, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "Grupo G", 0, "CMR", 3, 0, "BRA" },
                    { 49, false, new DateTime(2022, 12, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 50, false, new DateTime(2022, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 51, false, new DateTime(2022, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 52, false, new DateTime(2022, 12, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 53, false, new DateTime(2022, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 54, false, new DateTime(2022, 12, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 55, false, new DateTime(2022, 12, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 56, false, new DateTime(2022, 12, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 4, 0, "N/A" },
                    { 57, false, new DateTime(2022, 12, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 5, 0, "N/A" },
                    { 58, false, new DateTime(2022, 12, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 5, 0, "N/A" },
                    { 59, false, new DateTime(2022, 12, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 5, 0, "N/A" },
                    { 60, false, new DateTime(2022, 12, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 5, 0, "N/A" },
                    { 61, false, new DateTime(2022, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 6, 0, "N/A" },
                    { 62, false, new DateTime(2022, 12, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 6, 0, "N/A" },
                    { 63, false, new DateTime(2022, 12, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 7, 0, "N/A" },
                    { 64, false, new DateTime(2022, 12, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "", 0, "N/A", 7, 0, "N/A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_LocalId",
                table: "Matchs",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_QuinielaId",
                table: "Matchs",
                column: "QuinielaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_VisitorId",
                table: "Matchs",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResult_MatchId",
                table: "PlayerMatchResult",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResult_PlayerId",
                table: "PlayerMatchResult",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchResult_QuestionId",
                table: "PlayerMatchResult",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersRols_PlayerId",
                schema: "Security",
                table: "PlayersRols",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuinielaId",
                table: "Questions",
                column: "QuinielaId");

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
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Rols",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Quinielas");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
