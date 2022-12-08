using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCard40.Data.Migrations
{
    public partial class CreateDateCardPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateСreation",
                table: "CardPages",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateСreation",
                table: "CardPages");
        }
    }
}
