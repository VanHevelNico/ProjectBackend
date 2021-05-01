using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class _123 : Migration
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
                    LinkEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CafeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studentenclubs", x => x.StudentenclubId);
                    table.ForeignKey(
                        name: "FK_Studentenclubs_Cafes_CafeId",
                        column: x => x.CafeId,
                        principalTable: "Cafes",
                        principalColumn: "CafeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studentenclubs_Steden_StadId",
                        column: x => x.StadId,
                        principalTable: "Steden",
                        principalColumn: "StadId",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_StadId",
                table: "Cafes",
                column: "StadId");

            migrationBuilder.CreateIndex(
                name: "IX_EvenementenStudentenclub_OrganisatorsStudentenclubId",
                table: "EvenementenStudentenclub",
                column: "OrganisatorsStudentenclubId");

            migrationBuilder.CreateIndex(
                name: "IX_Studentenclubs_CafeId",
                table: "Studentenclubs",
                column: "CafeId");

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
