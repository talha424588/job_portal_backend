using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class SkillsToJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jobid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.id);
                    table.ForeignKey(
                        name: "FK_JobSkill_Jobs_Jobid",
                        column: x => x.Jobid,
                        principalTable: "Jobs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_Jobid",
                table: "JobSkill",
                column: "Jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkill");
        }
    }
}
