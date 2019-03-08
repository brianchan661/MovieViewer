using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieViewer.Data.Migrations
{
    public partial class Add_Popula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopulaResult",
                columns: table => new
                {
                    PosterPath = table.Column<string>(nullable: true),
                    Adult = table.Column<bool>(nullable: false),
                    Overview = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTimeOffset>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalTitle = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    BackdropPath = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    VoteCount = table.Column<long>(nullable: false),
                    Video = table.Column<bool>(nullable: false),
                    VoteAverage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulaResult", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopulaResult");
        }
    }
}
