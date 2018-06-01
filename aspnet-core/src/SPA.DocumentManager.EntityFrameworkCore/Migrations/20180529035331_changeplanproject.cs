using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class changeplanproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProject_PlanProjectType_ProjectNameId",
                table: "PlanProject");

            migrationBuilder.DropIndex(
                name: "IX_PlanProject_ProjectNameId",
                table: "PlanProject");

            migrationBuilder.RenameColumn(
                name: "ProjectNameId",
                table: "PlanProject",
                newName: "ProjectTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "PlanProjectTypeName",
                table: "PlanProjectType",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanProjectTypeId",
                table: "PlanProject",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanProject_PlanProjectTypeId",
                table: "PlanProject",
                column: "PlanProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject",
                column: "PlanProjectTypeId",
                principalTable: "PlanProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProject_PlanProjectType_PlanProjectTypeId",
                table: "PlanProject");

            migrationBuilder.DropIndex(
                name: "IX_PlanProject_PlanProjectTypeId",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "PlanProjectTypeId",
                table: "PlanProject");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                table: "PlanProject",
                newName: "ProjectNameId");

            migrationBuilder.AlterColumn<string>(
                name: "PlanProjectTypeName",
                table: "PlanProjectType",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanProject_ProjectNameId",
                table: "PlanProject",
                column: "ProjectNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProject_PlanProjectType_ProjectNameId",
                table: "PlanProject",
                column: "ProjectNameId",
                principalTable: "PlanProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
