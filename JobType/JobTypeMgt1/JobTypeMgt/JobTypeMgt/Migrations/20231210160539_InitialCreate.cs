using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTypeMgt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTypeHed",
                columns: table => new
                {
                    JobTypePk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypecode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JobTypeDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JobTypPrefix = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobTypActive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddUser = table.Column<int>(type: "int", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddMach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Session = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    timestamp_column = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeHed", x => x.JobTypePk);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeDet",
                columns: table => new
                {
                    JobTypeDetPk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypePk = table.Column<int>(type: "int", nullable: false),
                    JobTypeMilestone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTypStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeDet", x => x.JobTypeDetPk);
                    table.ForeignKey(
                        name: "FK_JobTypeDet_JobTypeHed_JobTypePk",
                        column: x => x.JobTypePk,
                        principalTable: "JobTypeHed",
                        principalColumn: "JobTypePk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTypeDet_JobTypePk",
                table: "JobTypeDet",
                column: "JobTypePk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTypeDet");

            migrationBuilder.DropTable(
                name: "JobTypeHed");
        }
    }
}
