using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class changeplanproject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "PlanProject");

            migrationBuilder.AlterColumn<int>(
                name: "PlanProjectTypeId",
                table: "PlanProject",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject",
                column: "PlanProjectTypeId",
                principalTable: "PlanProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject");

            migrationBuilder.AlterColumn<int>(
                name: "PlanProjectTypeId",
                table: "PlanProject",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "PlanProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject",
                column: "PlanProjectTypeId",
                principalTable: "PlanProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
