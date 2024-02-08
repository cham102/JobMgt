using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTypeMgt.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "JobTypeDet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "timestamp_column",
                table: "JobTypeDet",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "JobTypeDet");

            migrationBuilder.DropColumn(
                name: "timestamp_column",
                table: "JobTypeDet");
        }
    }
}
