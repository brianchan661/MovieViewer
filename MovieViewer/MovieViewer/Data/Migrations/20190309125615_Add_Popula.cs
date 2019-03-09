using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieViewer.Data.Migrations
{
    public partial class Add_Popula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "VoteAverage",
                table: "PopulaResult",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "insertDate",
                table: "PopulaResult",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteAverage",
                table: "PopulaResult");

            migrationBuilder.DropColumn(
                name: "insertDate",
                table: "PopulaResult");
        }
    }
}
