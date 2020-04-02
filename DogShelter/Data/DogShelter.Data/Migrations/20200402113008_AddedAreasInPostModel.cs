using Microsoft.EntityFrameworkCore.Migrations;

namespace DogShelter.Data.Migrations
{
    public partial class AddedAreasInPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Posts");
        }
    }
}
