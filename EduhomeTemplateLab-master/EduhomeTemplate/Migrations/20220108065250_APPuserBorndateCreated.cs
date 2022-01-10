using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduhomeTemplate.Migrations
{
    public partial class APPuserBorndateCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BornDate",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornDate",
                table: "AspNetUsers");
        }
    }
}
