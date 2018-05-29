using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class changeplanprojecttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubPlanProject");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "PlanProject",
                newName: "SubProjectName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PlanProject",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PlannedWorkLoad",
                table: "PlanProject",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectNameId",
                table: "PlanProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "PlanProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlanProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PlanProjectTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanProjectType", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProject_PlanProjectType_ProjectNameId",
                table: "PlanProject");

            migrationBuilder.DropTable(
                name: "PlanProjectType");

            migrationBuilder.DropIndex(
                name: "IX_PlanProject_ProjectNameId",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "PlannedWorkLoad",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "ProjectNameId",
                table: "PlanProject");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "PlanProject");

            migrationBuilder.RenameColumn(
                name: "SubProjectName",
                table: "PlanProject",
                newName: "ProjectName");

            migrationBuilder.CreateTable(
                name: "SubPlanProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PlanProjectId = table.Column<int>(nullable: false),
                    PlannedCost = table.Column<double>(nullable: false),
                    PlannedWorkLoad = table.Column<double>(nullable: false),
                    SubProjectName = table.Column<string>(maxLength: 200, nullable: false),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPlanProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPlanProject_PlanProject_PlanProjectId",
                        column: x => x.PlanProjectId,
                        principalTable: "PlanProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubPlanProject_PlanProjectId",
                table: "SubPlanProject",
                column: "PlanProjectId");
        }
    }
}
