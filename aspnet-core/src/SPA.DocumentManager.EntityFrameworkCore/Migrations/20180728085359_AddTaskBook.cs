using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SPA.DocumentManager.Migrations
{
    public partial class AddTaskBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskMainContent",
                table: "TaskBook");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "TaskBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskBook",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Funds",
                table: "TaskBook",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignDate",
                table: "TaskBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SpecialPlanTypeId",
                table: "TaskBook",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TaskBookNo",
                table: "TaskBook",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskContent",
                table: "TaskBook",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UndertakingUnitGroupId",
                table: "TaskBook",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SpecialPlanType",
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
                    SpecialPlanTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPlanType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contact = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 50, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    UnitGroupName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskBook_SpecialPlanTypeId",
                table: "TaskBook",
                column: "SpecialPlanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBook_UndertakingUnitGroupId",
                table: "TaskBook",
                column: "UndertakingUnitGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskBook_SpecialPlanType_SpecialPlanTypeId",
                table: "TaskBook",
                column: "SpecialPlanTypeId",
                principalTable: "SpecialPlanType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskBook_UnitGroup_UndertakingUnitGroupId",
                table: "TaskBook",
                column: "UndertakingUnitGroupId",
                principalTable: "UnitGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskBook_SpecialPlanType_SpecialPlanTypeId",
                table: "TaskBook");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskBook_UnitGroup_UndertakingUnitGroupId",
                table: "TaskBook");

            migrationBuilder.DropTable(
                name: "SpecialPlanType");

            migrationBuilder.DropTable(
                name: "UnitGroup");

            migrationBuilder.DropIndex(
                name: "IX_TaskBook_SpecialPlanTypeId",
                table: "TaskBook");

            migrationBuilder.DropIndex(
                name: "IX_TaskBook_UndertakingUnitGroupId",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "Funds",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "SignDate",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "SpecialPlanTypeId",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "TaskBookNo",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "TaskContent",
                table: "TaskBook");

            migrationBuilder.DropColumn(
                name: "UndertakingUnitGroupId",
                table: "TaskBook");

            migrationBuilder.AddColumn<string>(
                name: "TaskMainContent",
                table: "TaskBook",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
