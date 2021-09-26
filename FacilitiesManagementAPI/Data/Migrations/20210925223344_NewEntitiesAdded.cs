using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacilitiesManagementAPI.Data.Migrations
{
    public partial class NewEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PremisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractorTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    GreenLightId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PremiseName = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PremisesAdrressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PremisesCertificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateAssessed = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePassed = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReminderDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Pass = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    PremisesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremisesCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremisesCertificate_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PremisesTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripiton = table.Column<string>(type: "TEXT", nullable: true),
                    NoteId = table.Column<int>(type: "INTEGER", nullable: true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    PremisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremisesTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremisesTask_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PremisesTask_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoteContent = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PremisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PremiseCertId = table.Column<int>(type: "INTEGER", nullable: true),
                    PremisesCertId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Premises_PremisesId",
                        column: x => x.PremisesId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_PremisesCertificate_PremiseCertId",
                        column: x => x.PremiseCertId,
                        principalTable: "PremisesCertificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContractorId",
                table: "Notes",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PremiseCertId",
                table: "Notes",
                column: "PremiseCertId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PremisesId",
                table: "Notes",
                column: "PremisesId");

            migrationBuilder.CreateIndex(
                name: "IX_PremisesCertificate_PremisesId",
                table: "PremisesCertificate",
                column: "PremisesId");

            migrationBuilder.CreateIndex(
                name: "IX_PremisesTask_ContractorId",
                table: "PremisesTask",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_PremisesTask_PremisesId",
                table: "PremisesTask",
                column: "PremisesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PremisesTask");

            migrationBuilder.DropTable(
                name: "PremisesCertificate");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Premises");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");
        }
    }
}
