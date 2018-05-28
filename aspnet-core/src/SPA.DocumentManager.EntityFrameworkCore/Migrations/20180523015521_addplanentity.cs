using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class addplanentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompilationBasis = table.Column<string>(maxLength: 1000, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FileNo = table.Column<string>(maxLength: 100, nullable: false),
                    FinancialSource = table.Column<string>(maxLength: 1000, nullable: true),
                    FundBudget = table.Column<double>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MainContent = table.Column<string>(maxLength: 1000, nullable: true),
                    PlanName = table.Column<string>(maxLength: 100, nullable: false),
                    PlanYear = table.Column<string>(maxLength: 20, nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanProject",
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
                    PlanId = table.Column<int>(nullable: false),
                    PlannedCost = table.Column<double>(nullable: false),
                    ProjectName = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanProject_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialPlan",
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
                    PlanId = table.Column<int>(nullable: false),
                    PlannedCost = table.Column<double>(nullable: false),
                    SpecialPlanName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialPlan_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SubSpecialPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompleteDate = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MainContent = table.Column<string>(maxLength: 100, nullable: false),
                    SpecialPlanId = table.Column<int>(nullable: false),
                    SubPlanCost = table.Column<double>(nullable: false),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecialPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSpecialPlan_SpecialPlan_SpecialPlanId",
                        column: x => x.SpecialPlanId,
                        principalTable: "SpecialPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanProject_PlanId",
                table: "PlanProject",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPlan_PlanId",
                table: "SpecialPlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPlanProject_PlanProjectId",
                table: "SubPlanProject",
                column: "PlanProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecialPlan_SpecialPlanId",
                table: "SubSpecialPlan",
                column: "SpecialPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubPlanProject");

            migrationBuilder.DropTable(
                name: "SubSpecialPlan");

            migrationBuilder.DropTable(
                name: "PlanProject");

            migrationBuilder.DropTable(
                name: "SpecialPlan");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
