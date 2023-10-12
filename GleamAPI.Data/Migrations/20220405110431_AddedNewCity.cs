﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GleamAPI.Data.Migrations
{
    public partial class AddedNewCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "GleamVenues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "GleamVenues");
        }
    }
}
