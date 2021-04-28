using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenementen",
                columns: table => new
                {
                    EvenementenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkEvent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenementen", x => x.EvenementenId);
                });

            migrationBuilder.CreateTable(
                name: "Steden",
                columns: table => new
                {
                    StadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steden", x => x.StadId);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    CafeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.CafeId);
                    table.ForeignKey(
                        name: "FK_Cafes_Steden_StadId",
                        column: x => x.StadId,
                        principalTable: "Steden",
                        principalColumn: "StadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studentenclubs",
                columns: table => new
                {
                    StudentenclubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oprichtingsjaar = table.Column<int>(type: "int", nullable: false),
                    StadId = table.Column<int>(type: "int", nullable: false),
                    CafeId = table.Column<int>(type: "int", nullable: false),
                    CafeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentenclubs", x => x.StudentenclubId);
                    table.ForeignKey(
                        name: "FK_Studentenclubs_Cafes_CafeId1",
                        column: x => x.CafeId1,
                        principalTable: "Cafes",
                        principalColumn: "CafeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studentenclubs_Steden_StadId",
                        column: x => x.StadId,
                        principalTable: "Steden",
                        principalColumn: "StadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvenementenStudentenclub",
                columns: table => new
                {
                    EvenementenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisatorsStudentenclubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementenStudentenclub", x => new { x.EvenementenId, x.OrganisatorsStudentenclubId });
                    table.ForeignKey(
                        name: "FK_EvenementenStudentenclub_Evenementen_EvenementenId",
                        column: x => x.EvenementenId,
                        principalTable: "Evenementen",
                        principalColumn: "EvenementenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenementenStudentenclub_Studentenclubs_OrganisatorsStudentenclubId",
                        column: x => x.OrganisatorsStudentenclubId,
                        principalTable: "Studentenclubs",
                        principalColumn: "StudentenclubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentStudentenclub",
                columns: table => new
                {
                    ClubsStudentenclubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LedenStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentenclub", x => new { x.ClubsStudentenclubId, x.LedenStudentId });
                    table.ForeignKey(
                        name: "FK_StudentStudentenclub_Studente_LedenStudentId",
                        column: x => x.LedenStudentId,
                        principalTable: "Studente",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentenclub_Studentenclubs_ClubsStudentenclubId",
                        column: x => x.ClubsStudentenclubId,
                        principalTable: "Studentenclubs",
                        principalColumn: "StudentenclubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Evenementen",
                columns: new[] { "EvenementenId", "Beschrijving", "LinkEvent", "Naam" },
                values: new object[] { new Guid("8aec76b1-8519-4138-a4d3-f1e6708ce71a"), "Commilitones! Zet jullie bierpotten klaar voor deze cantus! 20u30 Io Vivat", null, "Zomercantus" });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadId", "Naam", "Provincie" },
                values: new object[] { 1, "Kortrijk", "West-Vlaanderen" });

            migrationBuilder.InsertData(
                table: "Steden",
                columns: new[] { "StadId", "Naam", "Provincie" },
                values: new object[] { 2, "Brugge", "West-Vlaanderen" });

            migrationBuilder.InsertData(
                table: "Cafes",
                columns: new[] { "CafeId", "Adres", "Naam", "StadId" },
                values: new object[,]
                {
                    { new Guid("5caafc20-dd10-44f7-8373-3bfbfe923709"), "GraafKarelDeGoedelaan 5, 8500 Kortrijk", "Tbunkertje", 1 },
                    { new Guid("1c61c178-c33f-470e-8d8a-d287b49ad8d9"), "Doorniksesteenweg 2, 8500 Kortrijk", "Tkanon", 1 },
                    { new Guid("c91d83ca-4c49-4b37-82a6-bd71cc4566e7"), "Eiermarkt 2, 8000 Brugge", "De Pick", 2 }
                });

            migrationBuilder.InsertData(
                table: "Studentenclubs",
                columns: new[] { "StudentenclubId", "Beschrijving", "CafeId", "CafeId1", "Naam", "Oprichtingsjaar", "StadId" },
                values: new object[] { new Guid("f279460b-36a7-4cf4-a998-4b3ccb2dd3a1"), "De club van Howest en Ugent -> De beste club van Kortrijk!", 0, null, "HsC Centaura", 1977, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_StadId",
                table: "Cafes",
                column: "StadId");

            migrationBuilder.CreateIndex(
                name: "IX_EvenementenStudentenclub_OrganisatorsStudentenclubId",
                table: "EvenementenStudentenclub",
                column: "OrganisatorsStudentenclubId");

            migrationBuilder.CreateIndex(
                name: "IX_Studentenclubs_CafeId1",
                table: "Studentenclubs",
                column: "CafeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Studentenclubs_StadId",
                table: "Studentenclubs",
                column: "StadId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentenclub_LedenStudentId",
                table: "StudentStudentenclub",
                column: "LedenStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvenementenStudentenclub");

            migrationBuilder.DropTable(
                name: "StudentStudentenclub");

            migrationBuilder.DropTable(
                name: "Evenementen");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Studentenclubs");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "Steden");
        }
    }
}
