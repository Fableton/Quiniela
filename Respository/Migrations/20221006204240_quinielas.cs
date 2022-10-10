using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class quinielas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 20, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 21, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 11, 21, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 11, 21, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2022, 11, 22, 4, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2022, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2022, 11, 22, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2022, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2022, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2022, 11, 23, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2022, 11, 23, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2022, 11, 23, 4, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2022, 11, 24, 4, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2022, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2022, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2022, 11, 24, 7, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "MatchGames",
                columns: new[] { "Id", "CanDraw", "Date", "Ended", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
                    { 17, true, new DateTime(2022, 11, 25, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "B", 0, "WAL", 2, 0, "IRN" },
                    { 18, true, new DateTime(2022, 11, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "A", 0, "QAT", 2, 0, "SEN" },
                    { 19, true, new DateTime(2022, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "A", 0, "NED", 2, 0, "ECU" },
                    { 20, true, new DateTime(2022, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "B", 0, "ENG", 2, 0, "USA" },
                    { 21, true, new DateTime(2022, 11, 26, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "D", 0, "TUN", 2, 0, "AUS" },
                    { 22, true, new DateTime(2022, 11, 26, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "C", 0, "POL", 2, 0, "KSA" },
                    { 23, true, new DateTime(2022, 11, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "D", 0, "FRA", 2, 0, "DEN" },
                    { 24, true, new DateTime(2022, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "C", 0, "ARG", 2, 0, "MEX" },
                    { 25, true, new DateTime(2022, 11, 27, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "E", 0, "JPN", 2, 0, "CRC" },
                    { 26, true, new DateTime(2022, 11, 27, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "F", 0, "BEL", 2, 0, "MAR" },
                    { 27, true, new DateTime(2022, 11, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "F", 0, "CRO", 2, 0, "CAN" },
                    { 28, true, new DateTime(2022, 11, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "E", 0, "ESP", 2, 0, "GER" },
                    { 29, true, new DateTime(2022, 11, 28, 4, 0, 0, 0, DateTimeKind.Unspecified), false, "G", 0, "CMR", 2, 0, "SRB" },
                    { 30, true, new DateTime(2022, 11, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), false, "H", 0, "KOR", 2, 0, "GHA" },
                    { 31, true, new DateTime(2022, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), false, "G", 0, "BRA", 2, 0, "SUI" },
                    { 32, true, new DateTime(2022, 11, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "H", 0, "POR", 2, 0, "URU" },
                    { 33, true, new DateTime(2022, 11, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "A", 0, "ECU", 3, 0, "SEN" },
                    { 34, true, new DateTime(2022, 11, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "A", 0, "NED", 3, 0, "QAT" },
                    { 35, true, new DateTime(2022, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "B", 0, "IRN", 3, 0, "USA" },
                    { 36, true, new DateTime(2022, 11, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "B", 0, "WAL", 3, 0, "ENG" },
                    { 37, true, new DateTime(2022, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "D", 0, "TUN", 3, 0, "FRA" },
                    { 38, true, new DateTime(2022, 11, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "D", 0, "AUS", 3, 0, "DEN" },
                    { 39, true, new DateTime(2022, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "C", 0, "POL", 3, 0, "ARG" },
                    { 40, true, new DateTime(2022, 11, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "C", 0, "KSA", 3, 0, "MEX" },
                    { 41, true, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "F", 0, "CRO", 3, 0, "BEL" },
                    { 42, true, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "F", 0, "CAN", 3, 0, "MAR" }
                });

            migrationBuilder.InsertData(
                table: "MatchGames",
                columns: new[] { "Id", "CanDraw", "Date", "Ended", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
                    { 43, true, new DateTime(2022, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "E", 0, "JPN", 3, 0, "ESP" },
                    { 44, true, new DateTime(2022, 12, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "E", 0, "CRC", 3, 0, "GER" },
                    { 45, true, new DateTime(2022, 12, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "H", 0, "KOR", 3, 0, "POR" },
                    { 46, true, new DateTime(2022, 12, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), false, "H", 0, "GHA", 3, 0, "URU" },
                    { 47, true, new DateTime(2022, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "G", 0, "SRB", 3, 0, "SUI" },
                    { 48, true, new DateTime(2022, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), false, "G", 0, "CMR", 3, 0, "BRA" }
                });

            migrationBuilder.InsertData(
                table: "Quinielas",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "TournamentId" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octavos de final", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuartos de final", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Semifinal", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finales", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { "N/A", "Por definir" });

            migrationBuilder.InsertData(
                table: "MatchGames",
                columns: new[] { "Id", "CanDraw", "Date", "Ended", "Group", "LocalGoals", "LocalId", "QuinielaId", "VisitorGoals", "VisitorId" },
                values: new object[,]
                {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Quinielas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quinielas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quinielas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quinielas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: "N/A");

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MatchGames",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
