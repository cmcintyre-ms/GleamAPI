using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GleamAPI.Data.Migrations
{
    public partial class AddedPicturePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "GleamVenues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "GleamVenues");
        }
    }
}
