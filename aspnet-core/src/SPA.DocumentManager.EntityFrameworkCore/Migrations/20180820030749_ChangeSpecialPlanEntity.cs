using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class ChangeSpecialPlanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialPlanName",
                table: "SpecialPlan");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "SpecialPlan",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MainContent",
                table: "SpecialPlan",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PlannedWorkLoad",
                table: "SpecialPlan",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialPlanTypeId",
                table: "SpecialPlan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "SpecialPlan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPlan_SpecialPlanTypeId",
                table: "SpecialPlan",
                column: "SpecialPlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPlan_SpecialPlanType_SpecialPlanTypeId",
                table: "SpecialPlan",
                column: "SpecialPlanTypeId",
                principalTable: "SpecialPlanType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPlan_SpecialPlanType_SpecialPlanTypeId",
                table: "SpecialPlan");

            migrationBuilder.DropIndex(
                name: "IX_SpecialPlan_SpecialPlanTypeId",
                table: "SpecialPlan");

            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "SpecialPlan");

            migrationBuilder.DropColumn(
                name: "MainContent",
                table: "SpecialPlan");

            migrationBuilder.DropColumn(
                name: "PlannedWorkLoad",
                table: "SpecialPlan");

            migrationBuilder.DropColumn(
                name: "SpecialPlanTypeId",
                table: "SpecialPlan");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "SpecialPlan");

            migrationBuilder.AddColumn<string>(
                name: "SpecialPlanName",
                table: "SpecialPlan",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
