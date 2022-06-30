using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCI.Project.Infraestructure.Data.Migrations
{
    public partial class AddDuration_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Notifications",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Notifications");
        }
    }
}
