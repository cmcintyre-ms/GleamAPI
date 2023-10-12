using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GleamAPI.Data.Migrations
{
    public partial class Updateschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "GleamVenues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramHandle",
                table: "GleamVenues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterHandle",
                table: "GleamVenues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "GleamVenues");

            migrationBuilder.DropColumn(
                name: "InstagramHandle",
                table: "GleamVenues");

            migrationBuilder.DropColumn(
                name: "TwitterHandle",
                table: "GleamVenues");
        }
    }
}
