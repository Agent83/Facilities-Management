using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacilitiesManagementAPI.Data.Migrations
{
    public partial class updateAccountant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premises_Accountant_AccountantId",
                table: "Premises");

            migrationBuilder.DropIndex(
                name: "IX_Premises_AccountantId",
                table: "Premises");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountantId1",
                table: "Premises",
                type: "uuid",
                nullable: true);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Premises_AccountantId",
                table: "Premises",
                column: "AccountantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premises_Accountant_AccountantId",
                table: "Premises",
                column: "AccountantId",
                principalTable: "Accountant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
