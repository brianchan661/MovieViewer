using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieViewer.Data.Migrations
{
    public partial class Update_Date_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "insertDate",
                table: "PopulaResult",
                newName: "InsertDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "PopulaResult",
                newName: "insertDate");
        }
    }
}
