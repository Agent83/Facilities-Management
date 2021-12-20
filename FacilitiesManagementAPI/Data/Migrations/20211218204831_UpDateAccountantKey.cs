using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilitiesManagementAPI.Data.Migrations
{
    public partial class UpDateAccountantKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premises_Accountant_AccountantId1",
                table: "Premises");

            migrationBuilder.DropIndex(
                name: "IX_Premises_AccountantId1",
                table: "Premises");

            migrationBuilder.DropColumn(
                name: "AccountantId1",
                table: "Premises");

            migrationBuilder.DropColumn(
                name: "PremisesId",
                table: "Accountant");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PremisesTask",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                table: "PremisesTask",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Premises",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Note",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contractors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActive",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_Premises_AccountantId",
                table: "Premises",
                column: "AccountantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premises_Accountant_AccountantId",
                table: "Premises",
                column: "AccountantId",
                principalTable: "Accountant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premises_Accountant_AccountantId",
                table: "Premises");

            migrationBuilder.DropIndex(
                name: "IX_Premises_AccountantId",
                table: "Premises");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PremisesTask",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                table: "PremisesTask",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Premises",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountantId1",
                table: "Premises",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Note",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Contractors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActive",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "PremisesId",
                table: "Accountant",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Premises_AccountantId1",
                table: "Premises",
                column: "AccountantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Premises_Accountant_AccountantId1",
                table: "Premises",
                column: "AccountantId1",
                principalTable: "Accountant",
                principalColumn: "Id");
        }
    }
}
